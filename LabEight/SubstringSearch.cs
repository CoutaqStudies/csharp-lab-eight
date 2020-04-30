using System;
using System.Collections.Generic;
using System.Text;

namespace LabEight
{
    public class SubstringSearch
    {
        public static int[] KMPSearch(String text, String pattern)
        {
            List<int> matches = new List<int>();
            int[] prefix = LongestPrefix(pattern);
            int i = 0, j = 0;
            while (i < pattern.Length)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }
                if (j == pattern.Length)
                {
                    Console.WriteLine("test");
                    matches.Add(i-j);
                    j = prefix[j - 1];
                }
                else if (i < pattern.Length && pattern[j] != text[i])
                {
                    if (j > 0)
                        j = prefix[j - 1];
                    else
                        i++;
                }
            }
            return matches.ToArray();
        }
        public static int[] LongestPrefix(string pattern)
        {
            int[] prefix = new int[pattern.Length];
            int length = 0;
            for (int i = 1; i < pattern.Length; i++)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    prefix[i] = length;
                }
                else
                {
                    if (length>0)
                    {
                        length = prefix[length - 1];
                        i--;
                    }
                    else
                    {
                        prefix[i] = length;
                    }
                }
            }
            return prefix;
        }
    }
}
