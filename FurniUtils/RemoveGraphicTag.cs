using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
namespace FurnidatatoSQL
{
    class RemoveGraphicTag : ToInterface
    {
        int count = 0;
        int errors = 0;
        public void HandleFurnidata(string[] items)
        {
            Console.Write("Exporting binaries...");
            foreach (string f in Directory.GetFiles("swfs"))
            {
                string item1 = f.Split('\\')[1].Substring(0,f.Split('\\')[1].IndexOf('.'));
                string furniture = ExportItem(item1);
            }
            Console.WriteLine("completed!");
            Console.Write("Replacing tags...");
            foreach (string d in Directory.GetDirectories("swfs"))
            {
                foreach (string f in Directory.GetFiles(d, "*.bin"))
                {
                    ReplaceTags(f);
                }
            }
            Console.WriteLine("completed!");
            Console.Write("Replacing binaries...");
            foreach (string d in Directory.GetDirectories("swfs"))
            {
                foreach (string f in Directory.GetFiles(d, "*.bin"))
                {
                    ReplaceBin(f, d);
                }
            }
            Console.WriteLine("completed!");
            Console.Write("Replacing Files...");
            foreach (string d in Directory.GetDirectories("swfs"))
            {
                foreach (string f in Directory.GetFiles(d, "*.swf"))
                {
                    string filename = f.Substring(f.LastIndexOf('\\') + 1, f.Length - (f.LastIndexOf('\\') + 1));
                    File.Replace(f, "swfs/" + filename, "swfs/backup/" + filename);
                }
            }
            Console.WriteLine("completed!");
            Console.Write("Deleting temporary files...");
            foreach(string d in Directory.GetDirectories("swfs"))
            {
                foreach (string f in Directory.GetFiles(d))
                    File.Delete(f);
                Directory.Delete(d);
            }
            Console.WriteLine("completed!");
            Console.WriteLine("Finished! Press the any key for the main menu.");
        }
        public string ExportItem(string furniname)
        {
            if(!Directory.Exists("swfs/" + furniname))
                Directory.CreateDirectory("swfs/" + furniname);
            if(!File.Exists("swfs/" + furniname +"/" + furniname + ".swf"))
                File.Copy("swfs/" + furniname + ".swf", "swfs/" + furniname + "/" + furniname + ".swf");
            ProcessStartInfo startInfo2 = new ProcessStartInfo("edit.bat", "d swfs/" + furniname + "/" + furniname + ".swf")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Process process2 = Process.Start(startInfo2);
            //process2.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            process2.BeginOutputReadLine();
            process2.Start();
            process2.WaitForExit();
            process2.Close();
            return "";
        }
        public string ReplaceTags(string path)
        {
                string content = File.ReadAllText(path);
                content = content.Replace("<graphics>", "");
                content = content.Replace("</graphics>", "");
                File.WriteAllText(path, content);
                return "";
        }
        public string ReplaceBin(string path, string dirname)
        {
            dirname = dirname.Substring(dirname.IndexOf('\\') + 1, dirname.Length - (dirname.IndexOf('\\') + 1));
            ProcessStartInfo startInfo2 = new ProcessStartInfo("edit.bat", "c " + dirname + " " + path.Substring(path.LastIndexOf('-') +1 ,path.LastIndexOf('.')-(path.LastIndexOf('-')+1)))
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Process process2 = Process.Start(startInfo2);
            //process2.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            process2.BeginOutputReadLine();
            process2.Start();
            process2.WaitForExit();
            process2.Close();
            return "";
        }
    }
}
