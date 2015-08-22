using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnidatatoSQL
{
    class About : ToInterface
    {
        public void HandleFurnidata(string[] items)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("#######################################");
                Console.WriteLine("#####        Furni Utils          #####");
                Console.WriteLine("#####      Coded by Rootkit       #####");
                Console.WriteLine("##### This Project is Open Source #####");
                Console.WriteLine("#######################################");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press the any key to continue.");
            }
            catch { }
        }
    }
}
