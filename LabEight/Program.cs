using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace LabEight
{
    class Program
    {
        static void Main(string[] args)
        {
            String filepath = "sorted.dat";
            String data = System.IO.File.ReadAllText(OsHelper.CompatiblePath(filepath, true));
            List<ListItem> strings = new List<ListItem>();
            int index = 0;

            foreach (String s in data.Split('\n'))
            {
                strings.Add(new ListItem(index, s));
                index++;
            }

            Console.Write("Search: ");
            String search = Console.ReadLine();
            
            Stopwatch stpw = new Stopwatch();
            TimeSpan ts;
            stpw.Start();
            
            stpw.Stop();
            ts = stpw.Elapsed;
            
            Console.WriteLine("Time: " + ts.Seconds + ":" + ts.Milliseconds);
        }
    }
}
