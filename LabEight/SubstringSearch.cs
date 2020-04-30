using System;
using System.Collections.Generic;
using System.Text;

namespace LabEight
{
    public class SubstringSearch
    {
        #region Knuth Morris Pratt
        public static int[] KMPSearch(String text, String pattern)
        {
            List<int> matches = new List<int>();
            int[] prefix = LongestPrefix(pattern);
            int i = 0, j = 0;
            while (i < text.Length)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }
                if (j == pattern.Length)
                {
                    matches.Add(i-j);
                    j = prefix[j - 1];
                }
                else if (i < text.Length && pattern[j] != text[i])
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
        #endregion
        #region Boyer Moore
        public static int[] BMSearch(string text, string pattern, char biggestPossibleChar)
        {
            List<int> matches = new List<int>();
            int[] badChars = BadCharacters(pattern, biggestPossibleChar.ToString().ToLower()[0]);
            int s = 0;
            while (text.Length-pattern.Length>=s)
            {
                int j = pattern.Length - 1;
                while (j >= 0 && pattern[j] == text[s+j])
                    j--;
                if (j < 0)
                {
                    matches.Add(s);
                    if (text.Length - pattern.Length > s)
                        s += pattern.Length - badChars[text[s + pattern.Length]];
                    else
                        s++;
                }
                else
                {
                    if (badChars[(text[s + j])] > j + 1)
                        s += Math.Abs(j - (badChars[text[s + j]]));
                    else
                        s++;
                }
            }

            return matches.ToArray();
        }
        public static int[] BMSearch(string text, string pattern)
        {
            List<int> matches = new List<int>();
            int[] badChars = BadCharacters(pattern, 'z');
            int s = 0;
            while (text.Length - pattern.Length >= s)
            {
                int j = pattern.Length - 1;
                while (j >= 0 && pattern[j] == text[s + j])
                    j--;
                if (j < 0)
                {
                    matches.Add(s);
                    if (text.Length - pattern.Length > s)
                        s += pattern.Length - badChars[text[s + pattern.Length]];
                    else
                        s++;
                }
                else
                {
                    if (j - badChars[(text[s + j])] >  1)
                        s += Math.Abs(j - badChars[(text[s + j])]);
                    else
                        s++;
                }
            }

            return matches.ToArray();
        }
        public static int[] BadCharacters(string pattern, char biggestPossibleChar)
        {
            int[] badChars = new int[((int) biggestPossibleChar)+1];
            for (int i = 0; i < badChars.Length; i++)
                badChars[i] = -1;
            for (int i = 0; i < pattern.Length; i++)
                badChars[(int)pattern[i]] = i;
            return badChars;
        }
        #endregion
        #region Native
        public static int[] NativeSearch(string text, string pattern)
        {
            List<int> matches = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != pattern[0])
                    continue;
                for (int j = 1, s = 0; j < pattern.Length && i + j < text.Length; j++)
                {
                        if (j == pattern.Length-1)
                            matches.Add(i);
                        if (text[i+j] != pattern[j])
                            break;
                }
            }
            return matches.ToArray();
        }
        #endregion
    }
}
