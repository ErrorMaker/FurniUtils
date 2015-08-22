using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace FurnidatatoSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            beginning:
            Console.WriteLine("FurniUtils");
            Console.WriteLine();
            Console.WriteLine("Your options:");
            Console.WriteLine("Convert Furnidata to Catalog_items [A]");
            Console.WriteLine("Convert Furnidata to Furniture [B]");
            Console.WriteLine("Convert Furnidata to Productdata [C]");
            Console.WriteLine("Download Furnis from images-eussl.habbo.com [D]");
            Console.WriteLine("Remove Graphic Tags from Furnis in \\swfs [E]");
            Console.WriteLine("Download Clothes from images-eussl.habbo.com [F]");
            Console.WriteLine("Download Furnidata from habbo.XX [G]");
            Console.WriteLine("Download Figuremap & figuredata from habbo.XX [H]");
            Console.WriteLine("Credits [I]");
            if (!Directory.Exists("swfs"))
                Directory.CreateDirectory("swfs");
            if (!Directory.Exists("swfs/backup"))
                Directory.CreateDirectory("swfs/backup");
            if (!Directory.Exists("swfs/clothes"))
                Directory.CreateDirectory("swfs/clothes");
            tryagain:
            string keychar = Console.ReadKey().KeyChar.ToString().ToLower();
            ToInterface interface1 = null;
            if (keychar == "a")
                interface1 = new ToCatalogItem();
            else if (keychar == "b")
                interface1 = new ToFurniture();
            else if (keychar == "c")
                interface1 = new ToProductdata();
            else if (keychar == "d")
                interface1 = new DownloadFurnis();
            else if (keychar == "e")
                interface1 = new RemoveGraphicTag();
            else if (keychar == "f")
                interface1 = new DownloadClothes();
            else if (keychar == "g")
                interface1 = new DownloadFurnidata();
            else if (keychar == "h")
                interface1 = new DownloadFiguremap();
            else if (keychar == "i")
                interface1 = new About();
            if (interface1 != null)
                interface1.HandleFurnidata(System.IO.File.ReadAllText("furnidata.txt",Encoding.Default).Replace("[[","[").Replace("]]","],").Split(']'));
            else
            { Console.WriteLine("Invalid command! Try again!"); goto tryagain; }
            Console.ReadKey();
            Console.Clear();
            goto beginning;
        }
    }
}
