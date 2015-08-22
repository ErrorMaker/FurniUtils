using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FurnidatatoSQL
{
    class ToFurniture : ToInterface
    {
        public string Name = "furniture";
        public void HandleFurnidata(string[] items)
        {
            int count = 0;
            int errors = 0;
            string final = "";
            uint modes = 1;
            Console.WriteLine("Interaction Modes:");
            if (uint.TryParse(Console.ReadLine(), out modes))
            {
                foreach (string item in items)
                {
                    string item1 = item.Replace("[", "");
                    item1 = item1.Replace("]", "");

                    string furniture = HandleItem(Regex.Split(item1.Replace("[", ""), "\",\""), modes);
                    if (furniture != "")
                        count++;
                    else
                        errors++;
                    final = final + "\n" + furniture;
                }
            }
            else
            {
                Console.WriteLine("Invalid Value! Try again.");
            }
            System.IO.File.WriteAllText("furniture.sql", final);
            Console.WriteLine("Finished (" + count + " successful, " + errors + " errors)! Press the any key for the main menu.");
        }

        public string HandleItem(string[] args, uint modes)
        {
            try
            {
            return "INSERT INTO `furniture` VALUES ('" + args[1].Replace("\"", "") + "', '" + args[2].Replace("\"", "") + "', '" + args[2].Replace("\"", "") + "', '" + args[0].Replace("\"", "").Replace(",","") + "', '" + args[5].Replace("\"", "") + "', '" + args[6].Replace("\"", "") + "', '1', '1', '0', '0', '" + args[1].Replace("\"","") + "', '1', '1', '1', '1', '1', 'default', '"+ modes+"', '0', '0', '0', '0', '0', '0', '');";
            }catch{  return ""; }
        }
    }
}
