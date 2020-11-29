using System;
using System.Collections.Generic;
using System.Text;

namespace WordCruncher
{
    class Program
    {
        static string targetString;
        static string currentString;
        static Dictionary<int, List<string>> substringsByLen;
        static Dictionary<string, int> substringOccurences;
        static List<string> combinedSubstrings;
        static HashSet<string> solutions;

        static void Main(string[] args)
        {
            var substrings = Console.ReadLine().Split(", ");
            targetString = Console.ReadLine();

            substringsByLen = new Dictionary<int, List<string>>();
            substringOccurences = new Dictionary<string, int>();

            foreach (var substring in substrings)
            {
                if (!targetString.Contains(substring))
                {
                    continue;
                }

                if (!substringsByLen.ContainsKey(substring.Length))
                {
                    substringsByLen.Add(substring.Length, new List<string>());
                }
                substringsByLen[substring.Length].Add(substring);

                if (!substringOccurences.ContainsKey(substring))
                {
                    substringOccurences.Add(substring, 0);
                }
                substringOccurences[substring]++;
            }

            currentString = string.Empty;
            combinedSubstrings = new List<string>();
            solutions = new HashSet<string>();

            FormString(targetString.Length);

            Console.WriteLine(String.Join(Environment.NewLine, solutions));
        }

        static void FormString(int length)
        {
            if (length == 0)
            {
                if (currentString == targetString)
                {
                    solutions.Add(String.Join(" ", combinedSubstrings));
                }
                return;
            }

            foreach (var kvp in substringsByLen)
            {
                if (kvp.Key > length)
                {
                    continue;
                }

                foreach (var substr in kvp.Value)
                {
                    if (substringOccurences[substr] > 0)
                    {
                        currentString += substr;

                        if (IsMatching())
                        {
                            substringOccurences[substr] -= 1;
                            combinedSubstrings.Add(substr);

                            FormString(length - substr.Length);

                            substringOccurences[substr] += 1;
                            combinedSubstrings.RemoveAt(combinedSubstrings.Count - 1);
                        }

                        currentString = currentString.Remove(currentString.Length - substr.Length, substr.Length);
                    }
                }
            }
        }

        private static bool IsMatching()
        {
            for (int i = 0; i < currentString.Length; i++)
            {
                if (currentString[i] != targetString[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
