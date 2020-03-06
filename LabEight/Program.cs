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
            int index = 1;

            foreach (String s in data.Split('\n'))
            {
                strings.Add(new ListItem(index, s));
                index++;
            }

            Console.Write("Linear search: ");
            String search = Console.ReadLine();

            int[] indexes;
            Stopwatch stpw = new Stopwatch();
            TimeSpan ts;

            stpw.Start();
                indexes = Search.LinearSearch(search, strings);
            stpw.Stop();
            ts = stpw.Elapsed;
            if (indexes.Length != 0)
                foreach (int i in indexes)
                {
                    Console.WriteLine(i);
                }
            else
                Console.WriteLine("Not found.");
            Console.WriteLine("Time: " + ts.Seconds + ":" + ts.Milliseconds);
        }
    }
}
