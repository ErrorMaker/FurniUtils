using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace FurnidatatoSQL
{
    class ToCatalogItem : ToInterface
    {
        public string Name = "furniture";
        private string final = "";
        public void HandleFurnidata(string[] items)
        {
            int count = 0;
            int errors = 0;
            Console.WriteLine();
            start:
            Console.WriteLine("Page ID: ");
            int pageId = 0;
            int credits = 0;
            int duckets = 0;
            int points = 0;
            int amount = 1;
            if (int.TryParse(Console.ReadLine(), out pageId))
            {
            credits:
                Console.WriteLine("Give a price (Credits):");
                if (int.TryParse(Console.ReadLine(), out credits))
                {
                duckets:
                    Console.WriteLine("Give a price (Duckets / pixel):");
                    if (int.TryParse(Console.ReadLine(), out duckets))
                    {
                    points:
                        Console.WriteLine("Give a price (Diamonds / VIP Points):");
                        if (int.TryParse(Console.ReadLine(), out points))
                        {
                        amount:
                            Console.WriteLine("Give a amount:");
                            if (int.TryParse(Console.ReadLine(), out amount))
                            {
                                foreach (string item in items)
                                {
                                    string item1 = item.Replace("[", "");
                                    item1 = item1.Replace("]", "");
                                    string furniture = HandleItem(Regex.Split(item1.Replace("[",""), "\",\""), pageId, credits, duckets, points, amount);
                                    if (furniture != "")
                                        count++;
                                    else
                                        errors++;
                                    final = final + "\n" + furniture;
                                }
                                System.IO.File.WriteAllText("catalog_items.sql", final);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Value! Try again.");
                                goto amount;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Value! Try again.");
                            goto points;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Value! Try again.");
                        goto duckets;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Value! Try again.");
                    goto credits;
                }
            }
            else
            {
                Console.WriteLine("Invalid Pageid! Try again.");
                goto start;
            }
            Console.WriteLine("Finished (" + count + " successful, " + errors + " errors)! Press the any key for the main menu.");
        }
        public string HandleItem(string[] args, int pageid, int credits, int duckets, int points, int amount)
        {
            try
            {
                return "INSERT INTO `catalog_items` VALUES ('" + args[1].Replace("\"", "") + "', '" + pageid + "', '" + args[1].Replace("\"", "") + "', '" + args[2].Replace("\"", "") + "', '" + credits + "', '" + duckets + "', '" + points + "', '" + amount + "', '0', '0', '0', '', '0', '0', '1', '0', '');";
            }
            catch {  return ""; }
        }
    }
}
