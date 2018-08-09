using System;
using System.Linq;
using System.Threading;

namespace Solver
{
    public delegate void OnCharacterChangedEventHandler(int X, int Y);
    
    public class BacktrackingSolver
    {
        public event OnCharacterChangedEventHandler OnCharacterChanged;
        private readonly char[,] _board;
        public bool Multithreaded { get; set; }
        public int SleepTimeBetweenTries { get; set; }

        public BacktrackingSolver(char[,] Board)
        {
            _board = Board;
        }

        public char[,] Solve()
        {
            if (Multithreaded)
            {
                var thread = new Thread(() => TrySolve());
                thread.Start();
            }
            else
            {
                TrySolve();
            }
            return _board;
        }

        private bool TrySolve()
        {
            for (var i = 0; i < 9; i++)
            {
                for (var k = 0; k < 9; k++)
                {
                    if (_board[i, k] != '.') continue;
                    for (var j = 1; j < 10; j++)
                    {
                        if (SleepTimeBetweenTries > 0)
                        {
                            //Thread.Sleep(SleepTimeBetweenTries);
                        }
                        var c = char.Parse($"{j}");
                        var isSquareCompliant = IsSquareCompliant(c, i, k);
                        if (!isSquareCompliant)
                        {
                            bool b = IsSquareCompliant(c, i, k);
                        }
                        if (IsSquareCompliant(c, i, k) 
                            && IsRowCompliant(c, k, i)
                            && IsColumnCompliant(c, i, k))
                        {
                            _board[i, k] = c;
                            OnCharacterChanged?.Invoke(i, k);
                            if (!TrySolve())
                            {
                                _board[i, k] = '.';
                                OnCharacterChanged?.Invoke(i, k);
                            }
                        }
                    }
                    if (_board[i, k] == '.') return false;
                }
            }

            return true;
        }

        public bool Validate()
        {
            for (var i = 0; i < 9; i++)
            {
                for (var k = 0; k < 9; k++)
                {
                    if (_board[i,k] == '.' 
                        || !IsRowCompliant(_board[i, k], k, i)                            
                        || !IsColumnCompliant(_board[i, k], i, k)
                        || !IsSquareCompliant(_board[i, k], i, k)) return false;
                }
            }
            return true;
        }


        private bool IsSquareCompliant(char N, int X, int Y)
        {
            var offsetX = (int)(X / 3);
            var offsetY = (int)(Y / 3);

            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    var newX = offsetX + x;
                    var newY = offsetY + y;
                    if (_board[newX, newY] == N && newX != X && newY != Y) return false;
                }
            }

            return true;
        }

        private bool IsRowCompliant(char N, int Y, int X)
        {
            for (var i = 0; i < 9; i++)
            {
                if (_board[i, Y] == N && i != X) return false;
            }

            return true;
        }

        private bool IsColumnCompliant(char N, int X, int Y)
        {
            for (var i = 0; i < 9; i++)
            {
                if (_board[X, i] == N && i != Y) return false;
            }

            return true;
        }
    }
}