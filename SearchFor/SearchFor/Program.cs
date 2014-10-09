using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SearchFor
{
    class Program
    {
        static Random rand = new Random();
        static List<string> results = new List<string>();
        static void Main(string[] args)
        {
            string target = "*.mp3";
            if (args.Count() > 0)
            {
                target = args[0].Trim();
            }

            

            foreach (string drive in Directory.GetLogicalDrives())
            {               
                
                Search(drive,target);
                
            }

            string resultfile=target.Split('/').Last().Replace("*","").Trim('.')+".txt";

            File.WriteAllLines(resultfile,results, Encoding.UTF8);

            Console.WriteLine("Return(\""+Path.GetFullPath(resultfile)+"\")");

        }

        static void Search(string dir, string target)
        {
            try
            {
                foreach (string file in Directory.GetFiles(dir, target, SearchOption.AllDirectories))
                {
                    results.Add(file);
                }
            }
            catch
            {
                try
                {
                    foreach (string file in Directory.GetFiles(dir, target, SearchOption.TopDirectoryOnly))
                    {
                        results.Add(file);
                    }

                    Parallel.ForEach(Directory.GetDirectories(dir), directory =>
                    {
                        try
                        {
                            Search(directory, target);
                        }
                        catch { }
                    });
                    
                }
                catch { }
            }            
        }
    }
}

