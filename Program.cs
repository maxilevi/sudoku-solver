using System;

namespace Solver
{
    public static class Program
    {
        public static void Main(string[] Args)
        {
            var solver = new BacktrackingSolver(Input);
            var result = solver.Solve();
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
