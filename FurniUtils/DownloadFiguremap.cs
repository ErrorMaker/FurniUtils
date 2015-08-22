using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace FurnidatatoSQL
{
    class DownloadFiguremap : ToInterface
    {
        public void HandleFurnidata(string[] items)
        {
            if (File.Exists("figuredata.xml"))
                File.Delete("figuredata.xml");
            if (File.Exists("figuremap.xml"))
                File.Delete("figuremap.xml");
            Console.WriteLine("Name the SWF Build (for example: PRODUCTION-201507062205-18729)");
            string build = Console.ReadLine();
            Console.WriteLine("Name the Hotel (for example \"de\" or \"com\")");
            string hotel = Console.ReadLine();
            WebClient webClient = new WebClient();
            try
            {
                Console.Write("Downloading figuremap.xml...");
                webClient.DownloadFile("http://images-eussl.habbo.com/dcr/gordon/" + build + "/figuremap.xml", "figuremap.xml");
                Console.WriteLine("completed!");
            }
            catch { Console.WriteLine("failed!"); }
            try
            {
                Console.Write("Downloading figuredata.xml...");
                webClient.DownloadFile("http://www.habbo." + hotel + "/gamedata/figuredata", "figuredata.xml");
                Console.WriteLine("completed!");
            }
            catch { Console.WriteLine("failed!"); }
            Console.WriteLine("Press the any key for the main menu.");
        }
    }
}
