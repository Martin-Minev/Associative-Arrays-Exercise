using System;
using System.Linq;
using System.Collections.Generic;

namespace Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> occurrences = new Dictionary<char, int>();

            foreach (var letter in input)
            {
                if (letter != ' ')
                {
                    if (!occurrences.ContainsKey(letter))
                    {
                        occurrences.Add(letter, 0);
                    }
                    occurrences[letter]++;
                }
            }
            foreach (var item in occurrences)
            {
                char currentChar = item.Key;
                int currentInt = item.Value;
                Console.WriteLine($"{ currentChar } -> { currentInt}");
            }
        }
    }
}
