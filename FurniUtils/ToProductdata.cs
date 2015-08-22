using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FurnidatatoSQL
{
    class ToProductdata : ToInterface
    {
        public void HandleFurnidata(string[] items)
        {
            Console.WriteLine();
            int count = 0;
            int errors = 0;
            string final = "";
            foreach (string item in items)
            {
                string item1 = item.Replace("[", "");
                item1 = item1.Replace("]", "");
                string furniture = HandleItem(Regex.Split(item1.Replace("[", ""), "\",\""));
                if (furniture != "")
                    count++;
                else
                    errors++;
                final = final + "\n" + furniture;
            }
            System.IO.File.WriteAllText("productdata.txt", final,Encoding.Default);
            Console.WriteLine("Finished (" + count + " successful, " + errors + " errors)! Press the any key for the main menu.");
        }
        public string HandleItem(string[]args)
        {
            try
            {
                return "[\"" + args[2].Replace("\"", "") + "\",\"" + args[8].Replace("\"","") + "\",\"" + args[8].Replace("\"","") +"\"],";
            }
            catch { return ""; }
        }
    }
}
