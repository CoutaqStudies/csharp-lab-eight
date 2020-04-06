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
            //search for 555 and 695803 
            String filepath = "sorted.dat";
            String data = System.IO.File.ReadAllText(OsHelper.CompatiblePath(filepath, true));
            List<String> strings = new List<String>();
            int index = 0;

            foreach (String s in data.Split('\n'))
            {
                strings.Add(s);
            }

            int[] nums =new int[strings.Count];

            foreach (String s in strings)
            {
                nums[index] = int.Parse(s);
                index++;
            }

            Console.Write("Linear search: ");
            int searchFor = int.Parse(Console.ReadLine());


            int[] indexes;
            Stopwatch stpw = new Stopwatch();
            TimeSpan ts;

            stpw.Start();
            int found = +Search.LinearSearch(nums, searchFor);
            if(found!=-1) 
                Console.WriteLine("array["+found+"] = "+searchFor);
            else
                Console.WriteLine("Not found!");
            stpw.Stop();
            ts = stpw.Elapsed;
            Console.WriteLine("Time: " + ts.Seconds + ":" + ts.Milliseconds);

            Console.WriteLine("Binary:");
            stpw.Reset();
            found = +Search.BinarySearch(nums, searchFor);
            if (found != -1)
                Console.WriteLine("array[" + found + "] = " + searchFor);
            else
                Console.WriteLine("Not found!");
            stpw.Stop();
            ts = stpw.Elapsed;
            Console.WriteLine("Time: " + ts.Seconds + ":" + ts.Milliseconds);

            Console.WriteLine("Interpolation:");
            stpw.Reset();
            found = +Search.InterpolationSearch(nums, searchFor);
            if (found != -1)
                Console.WriteLine("array[" + found + "] = " + searchFor);
            else
                Console.WriteLine("Not found!");
            stpw.Stop();
            ts = stpw.Elapsed;
            Console.WriteLine("Time: " + ts.Seconds + ":" + ts.Milliseconds);
        }
    }
}
