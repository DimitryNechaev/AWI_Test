using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartA
{
    public static class WordReverseHelper
    {
        internal static void Reverse(string str, int start, int end, char[] buffer)
        {
            var len = end - start + 1;
            if (str[end] == ' ')
            {
                buffer[end] = ' ';
                len--;
            }

            for (int i = 0; i < len; i++)
            {
                buffer[start + i] = str[start + len - i - 1];
            }
        }

        public static string ReverseWholeWords(string str)
        {
            var prevWordEnd = 0;
            var buffer = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' || i == str.Length - 1)
                {
                    Reverse(str, prevWordEnd, i, buffer);
                    prevWordEnd = i+1;
                }
            }
            return new string(buffer);
        }
    }
}
