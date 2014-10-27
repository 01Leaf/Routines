using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PIPE
{
    class Program
    {
        static Process prc=new Process();
        static void Main(string[] args)
        {
            Console.WriteLine("LinkRID(INPUT,true)");

            if (args.Count() > 0)
            {
#if !DEBUG
                try
                {
#endif
                    prc.StartInfo.FileName = args[0];
                    if (args.Count() > 1)
                    {
                        prc.StartInfo.Arguments = args[1];
                    }

                    prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    prc.StartInfo.CreateNoWindow = true;
                    prc.StartInfo.UseShellExecute = false;

                    prc.StartInfo.RedirectStandardInput = true;
                    prc.StartInfo.RedirectStandardOutput = true;

                    prc.OutputDataReceived += new DataReceivedEventHandler(prc_OutputDataReceived);
                    
                    prc.EnableRaisingEvents = true;
                    prc.Exited += new EventHandler(prc_Exited);
                    prc.Start();

                    prc.BeginOutputReadLine();
                    
                    
#if !DEBUG

                }
                catch { }
#endif
            }

            while (true)
            {
                prc.StandardInput.WriteLine(Console.ReadLine());

            }

        }

        static void prc_Exited(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        static void prc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != "")
            {
                Console.WriteLine("MSG(\"" + e.Data + "\")");
            }
        }
    }
}
