using System;

namespace Solver
{
    public class SudokuPrinter
    {
        public void Print(char [,] Input)
        {
            for (var i = 0; i < Input.GetLength(0); i++)
            {
                for (var k = 0; k < Input.GetLength(1); k++)
                {
                    Console.Write("| ");
                    Console.ForegroundColor = this.ColorFromCharacter(Input[i, k]);
                    Console.Write($"{Input[i,k]} ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if((k+1) % 3 == 0) Console.Write("|   ");
                }
                Console.WriteLine(string.Empty);
                if ((i+1) % 3 == 0) Console.Write($"{Environment.NewLine}");
            }
        }

        private ConsoleColor ColorFromCharacter(char Input)
        {
            return Input == '.' ? ConsoleColor.Yellow : ConsoleColor.Red;
        }
    }
}