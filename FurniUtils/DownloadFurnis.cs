using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
namespace FurnidatatoSQL
{
    class DownloadFurnis : ToInterface
    {
        int fullcount = 0;
        int count = 0;
        public void HandleFurnidata(string[] items)
        {
            int errors = 0;
            fullcount = items.Length;
            foreach (string item in items)
            {
                string item1 = item.Replace("[", "");
                item1 = item1.Replace("]", "");
                string furniture = HandleItem(Regex.Split(item1.Replace("[", ""), "\",\""));
                if (furniture != "")
                    count++;
                else
                {
                    errors++;
                }
            }
            Console.WriteLine("Finished (" + count + " successful, " + errors + " errors)! Press the any key for the main menu.");
        }
        private WebClient webClient = new WebClient();
        public string HandleItem(string[] args)
        {
            try
            {
                string filename = "";
                if (args[2].Contains("*"))
                {
                    filename = args[2].Replace("\"", "").Substring(0, args[2].IndexOf("*"));
                }
                else
                    filename = args[2].Replace("\"", "");
                try
                {

                    if (!File.Exists("swfs/" + filename + ".swf"))
                    {

                        Console.Write("Downloading furni " + filename + "   (" + (count +1)+ " of " + fullcount + ")                ");
                        Console.SetCursorPosition(0, Console.CursorTop);
                        webClient.DownloadFile("http://images-eussl.habbo.com/dcr/hof_furni/" + args[3].Replace("\"", "") + "/" + filename + ".swf", "swfs\\" + filename + ".swf");
                    }
                    return "ok!";
                }
                catch {}
            }catch{ }
            return "";
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
