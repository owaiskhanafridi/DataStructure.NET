using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025
{
    class PracticeJune8
    {
        public static string Encoder(string text)
        {
            //abc
            string reverse = string.Empty;
            StringBuilder sb = new StringBuilder();
            char reversed;
            foreach (var ch in text)
            {
                if (char.IsLetter(ch))
                {
                    if (char.IsUpper(ch))
                    {
                        reversed = (char)('Z' - (ch - 'A'));
                    }
                    else
                    {
                        reversed = (char)('z' - (ch - 'a'));
                    }

                    sb.Append(reversed);
                }
                else
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        public static Dictionary<char, int> Frequency(string value)
        {
            var frequency = new Dictionary<char, int>();

            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                frequency[ch] = 0;
            }

            foreach(var ch in value)
            {
                if(frequency.ContainsKey(ch))
                    frequency[ch] += 1;
            }
            
            return frequency;
        }
    }
}
