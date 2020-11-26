using System;

namespace _8QueensPuzzle
{
    class Program
    {
        private const int CHESSBOARD_SIZE = 8;
        private static int counter = 0;

        static void Main(string[] args)
        {
            char[,] chessboard = GenerateChessboard();

            PlaceQueens(chessboard, 0);
            Console.WriteLine(counter);
        }

        private static void PlaceQueens(char[,] chessboard, int row)
        {
            if (row == CHESSBOARD_SIZE)
            {
                PrintChessboard(chessboard);
                counter++;
                return;
            }

            for (int col = 0; col < CHESSBOARD_SIZE; col++)
            {
                if (IsSafe(chessboard, row, col))
                {
                    chessboard[row, col] = '*';
                    PlaceQueens(chessboard, row + 1);
                    chessboard[row, col] = '-';
                }
            }
        }

        private static bool IsSafe(char[,] chessboard, int row, int col)
        {
            for (int i = 1; i < CHESSBOARD_SIZE; i++)
            {
                if (row + i < CHESSBOARD_SIZE && chessboard[row + i, col] == '*')
                {
                    return false;
                }

                if (row - i >= 0 && chessboard[row - i, col] == '*')
                {
                    return false;
                }

                if (col + i < CHESSBOARD_SIZE && chessboard[row, col + i] == '*')
                {
                    return false;
                }

                if (col - i >= 0 && chessboard[row, col - i] == '*')
                {
                    return false;
                }

                if (row - i >= 0 && col - i >= 0 && chessboard[row - i, col - i] == '*')
                {
                    return false;
                }

                if (row - i >= 0 && col + i < CHESSBOARD_SIZE && chessboard[row - i, col + i] == '*')
                {
                    return false;
                }

                if (row + i < CHESSBOARD_SIZE && col + i < CHESSBOARD_SIZE && chessboard[row + i, col + i] == '*')
                {
                    return false;
                }

                if (row + i < CHESSBOARD_SIZE && col - i >= 0 && chessboard[row + i, col - 1] == '*')
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintChessboard(char[,] chessboard)
        {
            for (int i = 0; i < CHESSBOARD_SIZE; i++)
            {
                for (int j = 0; j < CHESSBOARD_SIZE; j++)
                {
                    Console.Write(chessboard[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static char[,] GenerateChessboard()
        {
            char[,] chessboard = new char[CHESSBOARD_SIZE, CHESSBOARD_SIZE];

            for (int i = 0; i < CHESSBOARD_SIZE; i++)
            {
                for (int j = 0; j < CHESSBOARD_SIZE; j++)
                {
                    chessboard[i, j] = '-';
                }
            }

            return chessboard;
        }
    }
}
