using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
namespace FurnidatatoSQL
{
    class DownloadClothes: ToInterface
    {
        public void HandleFurnidata(string[] items)
        {
            int count = 0;
            int error = 0;
            XmlTextReader reader = new XmlTextReader("figuremap.xml");
            WebClient webClient = new WebClient();
            string production = "";
            Console.WriteLine("Name the SWF Build (for example: PRODUCTION-201507062205-18729)");
            production = Console.ReadLine();
            while(reader.Read())
            {
                if (reader.Name == "lib" && reader.NodeType == XmlNodeType.Element)
                {
                    while (reader.MoveToNextAttribute())
                    {
                        int idk = 0;
                        if (reader.Name == "id" && !int.TryParse(reader.Value, out idk))
                        {
                            try
                            {
                                Console.Write("Downloading cloth " + reader.Value + "                  ");
                                Console.SetCursorPosition(0, Console.CursorTop);
                                webClient.DownloadFile("http://images-eussl.habbo.com/dcr/gordon/" + production + "/" + reader.Value + ".swf", "swfs/clothes/" + reader.Value + ".swf");
                                count++;
                            }
                            catch
                            {
                                error++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Finished (" + count + " successful, " + error + " errors)! Press the any key for the main menu.");
        }
    }
}
