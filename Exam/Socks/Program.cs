using System;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] socks1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] socks2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int lcs = GetLCS(socks1, socks2);
            Console.WriteLine(lcs);
        }

        private static int GetLCS(int[] socks1, int[] socks2)
        {
            var lcsTable = new int[socks1.Length + 1, socks2.Length + 1];

            for (int r = 1; r < lcsTable.GetLength(0); r++)
            {
                for (int c = 1; c < lcsTable.GetLength(1); c++)
                {
                    if (socks1[r - 1] == socks2[c - 1])
                    {
                        lcsTable[r, c] = lcsTable[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcsTable[r, c] = Math.Max(lcsTable[r - 1, c], lcsTable[r, c - 1]);
                    }
                }
            }

            return lcsTable[lcsTable.GetLength(0) - 1, lcsTable.GetLength(1) - 1];
        }
    }
}
