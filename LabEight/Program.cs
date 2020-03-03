using System;
using System.Collections.Generic;
using System.IO;

namespace LabEight
{
    class Program
    {
        static void Main(string[] args)
        {
            String filepath = "sorted.dat";
            String data = System.IO.File.ReadAllText(OsHelper.CompatiblePath(filepath, true));
            List<String> strings = new List<String>();
            foreach (String s in data.Split('\n'))
            {
                strings.Add(s);
            }
            Console.Write("Search: ");
            String search = Console.ReadLine();
            List<String> results = new List<String>();
            
            results = strings.FindAll(s => s.Equals(search));
            if (results.Count == 0)
                Console.WriteLine("Not Found.");
            foreach(String s in results)
            {
                Console.WriteLine(s);
            }
        }
    }
}
