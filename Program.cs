using System;

namespace Solver
{
    public static class Program
    {
        public static void Main(string[] Args)
        {
            var printer = new SudokuPrinter();
            var original = Input.Clone() as char[,];
            var solver = new BacktrackingSolver(Input);
            printer.Print(original, Input);
            solver.OnCharacterChanged += delegate(int X, int Y)
            {
                printer.Print(original, Input, X, Y);
            };
            var result = solver.Solve();
            Console.WriteLine(solver.Validate() ? $"Sudoku was completed succesfully!" : "Failed to correctly complete sudoku.");
        }

        private static readonly char[,] Input =
        {
            {
                '5', '3', '.',
                '.', '7', '.',
                '.', '.', '.'
            },
            {
                '6', '.', '.',
                '1', '9', '5',
                '.', '.', '.'
            },
            {
                '.', '9', '8',
                '.', '.', '.',
                '.', '6', '.'
            },
            {
                '8', '.', '.',
                '.', '6', '.',
                '.', '.', '3'
            },
            {
                '4', '.', '.',
                '8', '.', '3',
                '.', '.', '1'
            },
            {
                '7', '.', '.',
                '.', '2', '.',
                '.', '.', '6'
            },
            {
                '.', '6', '.',
                '.', '.', '.',
                '2', '8', '.'
            },
            {
                '.', '.', '.',
                '4', '1', '9',
                '.', '.', '5'
            },
            {
                '.', '.', '.',
                '.', '8', '.',
                '.', '7', '9'
            }
        };
    }
}
