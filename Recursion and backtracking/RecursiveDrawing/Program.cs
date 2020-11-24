using System;
using System.Text;

namespace RecursiveDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfChars = int.Parse(Console.ReadLine());
            Draw(numOfChars);
        }

        static void Draw(int numOfChars)
        {
            if (numOfChars == 0)
            {
                return;
            }

            Console.WriteLine(new String('*', numOfChars));
            Draw(numOfChars - 1);
            Console.WriteLine(new String('#', numOfChars));
        }
    }
}
