using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
namespace FurnidatatoSQL
{
    class DownloadFurnidata : ToInterface
    {
        public void HandleFurnidata(string[] items)
        {
            if (File.Exists("furnidata.txt"))
                File.Delete("furnidata.txt");
            Console.WriteLine();
            Console.WriteLine("Select a Hotel (for example \"de\" or \"com\"");
            string hotel = Console.ReadLine();
            Console.Write("Downloading Furnidata...");
            try
            {
                new WebClient().DownloadFile("http://habbo." + hotel + "/gamedata/furnidata", "furnidata.txt");
                Console.WriteLine("completed!");
            }
            catch { Console.WriteLine("error!"); }
            Console.WriteLine("Press the any key for the main menu.");
        }
    }
}
