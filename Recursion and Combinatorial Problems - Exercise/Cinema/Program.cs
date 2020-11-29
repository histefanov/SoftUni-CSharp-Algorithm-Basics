using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    class Program
    {
        static HashSet<int> lockedSeats;
        static bool[] seatedPersons;
        static string[] arrangement;

        static void Main(string[] args)
        {
            var persons = Console.ReadLine()
                .Split(", ")
                .ToList();           
            lockedSeats = new HashSet<int>();
            
            arrangement = new string[persons.Count];

            string input;
            while ((input = Console.ReadLine()) != "generate")
            {
                string[] inputTokens = input.Split(" - ");
                string name = inputTokens[0];
                int seatNumber = int.Parse(inputTokens[1]) - 1;

                persons.Remove(name);
                arrangement[seatNumber] = name;
                lockedSeats.Add(seatNumber);
            }

            seatedPersons = new bool[persons.Count];
            Permute(persons, 0);
        }

        private static void Permute(List<string> persons, int index)
        {
            if (index >= arrangement.Length)
            {
                PrintArrangement();
                return;
            }

            if (lockedSeats.Contains(index))
            {
                Permute(persons, index + 1);
                return;
            }

            for (int i = 0; i < persons.Count; i++)
            {
                if (!seatedPersons[i])
                {
                    arrangement[index] = persons[i];
                    seatedPersons[i] = true;
                    Permute(persons, index + 1);
                    seatedPersons[i] = false;
                }
            }
        }

        private static void PrintArrangement()
        {
            Console.WriteLine(String.Join(" ", arrangement));
        }

        private static void Swap(string[] persons, int index1, int index2)
        {
            string temp = persons[index1];
            persons[index1] = persons[index2];
            persons[index2] = temp;
        }
    }
}
