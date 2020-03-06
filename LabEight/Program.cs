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
            List<ListItem> results = new List<ListItem>();
            Stopwatch stpw = new Stopwatch();
            stpw.Start();
            results = strings.FindAll(s => s.value.Equals(search));
            stpw.Stop();
            if (results.Count == 0)
                Console.WriteLine("Not Found.");
            List<int> indexes = new List<int>();
            foreach (ListItem li in results)
            {
                indexes.Add(li.index);
                Console.Write(li.index);
            }
            Console.WriteLine("Elapsed time: "+stpw.ElapsedMilliseconds);
        }
    }
}
