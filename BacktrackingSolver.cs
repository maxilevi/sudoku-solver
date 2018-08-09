namespace Solver
{
    public class BacktrackingSolver
    {
        private readonly char[,] _board;

        public BacktrackingSolver(char[,] Board)
        {
            _board = Board;
        }

        public char[,] Solve()
        {
            TrySolve();
            return _board;
        }

        private bool TrySolve()
        {
            for (var i = 0; i < 9; i++)
            {
                for (var k = 0; k < 9; k++)
                {
                    if (_board[i, k] == '.')
                    {
                        var missingChar = FindMissing(i, k);
                        if (missingChar == default(char)) return false;
                        _board[i, k] = missingChar;
                        if (TrySolve()) continue;
                        _board[i, k] = missingChar;
                        return false;
                    }
                }
            }

            return true;
        }

        private char FindMissing(int X, int Y)
        {
            var chars = new[] {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
            for (var k = 0; k < chars.Length; k++)
            {
                var c = chars[k];
                if (IsSquareCompliant(c, X, Y)
                    && IsRowCompliant(c, Y)
                    && IsColumnCompliant(c, X)) return c;
            }
            return default(char);
        }

        private bool IsSquareCompliant(char N, int X, int Y)
        {
            var offsetX = X % 3;
            var offsetY = Y % 3;

            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    if (_board[offsetX + x, offsetY + y] == N) return false;
                }
            }

            return true;
        }

        private bool IsRowCompliant(char N, int Y)
        {
            for (var i = 0; i < 9; i++)
            {
                if (_board[i, Y] == N) return false;
            }

            return true;
        }

        private bool IsColumnCompliant(char N, int X)
        {
            for (var i = 0; i < 9; i++)
            {
                if (_board[X, i] == N) return false;
            }

            return true;
        }
    }
}