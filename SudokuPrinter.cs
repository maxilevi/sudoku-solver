using System;

namespace Solver
{
    public class SudokuPrinter
    {
        public void Print(char [,] OriginalInput, char [,] Input, int HighlightX = -1, int HighlightY = -1)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            for (var i = 0; i < Input.GetLength(0); i++)
            {
                for (var k = 0; k < Input.GetLength(1); k++)
                {
                    Console.Write("| ");
                    Console.ForegroundColor = HighlightX == i && HighlightY == k 
                        ?  ConsoleColor.Cyan
                        : ColorFromCharacter(Input[i, k], OriginalInput[i, k]);
                    Console.Write($"{Input[i,k]} ");
                    Console.ForegroundColor = ConsoleColor.White;
                    if((k+1) % 3 == 0) Console.Write("|   ");
                }
                Console.WriteLine(string.Empty);
                if ((i+1) % 3 == 0) Console.Write($"{Environment.NewLine}");
            }
        }

        private static ConsoleColor ColorFromCharacter(char Input, char Original)
        {
            return Original == Input 
                ? (Input == '.' ? ConsoleColor.Green : ConsoleColor.DarkMagenta)
                : ConsoleColor.Yellow;
        }
    }
}