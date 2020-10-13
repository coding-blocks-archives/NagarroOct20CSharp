using System;

namespace Backtracking
{
    class BacktrackingQs
    {
        static void Main(string[] args)
        {
            // 1. MAZE PATH
            int[,] maze =
            {
                {0,1,0,0 } ,
                {0,0,0,0 } ,
                {0,1,0,0 } ,
                {0,0,1,0 } ,
            };

            bool[,] visited = new bool[maze.GetLength(0), maze.GetLength(1)];
            BlockedMaze(maze, 0, 0, maze.GetLength(0) - 1, maze.GetLength(1) - 1, "", visited);

            // 2. WORD SEARCH
            char[,] board =
            {
                { 'A', 'B', 'C', 'E'},
                { 'S', 'F', 'C', 'S'},
                { 'A', 'D', 'E', 'E'}
            };

            string word = "SEE";
            bool[,] visit = new bool[board.GetLength(0), board.GetLength(1)];
          
            bool res = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == word[0])
                    {
                        res = WordSearch(board, i, j, board.GetLength(0) - 1, board.GetLength(1) - 1, word, 0, visit);
                        if (res == true)
                            break;
                    }
                }

                if (res == true)
                    break;

            }

            Console.WriteLine(res);

            // 3. SUDOKU SOLVER
            int[,] grid =
            {
                { 0, 0, 0 ,0 ,7 ,0 ,0 ,0 ,0 } ,
                { 6, 0, 0, 1, 9, 5, 0, 0, 0 } ,
                { 0, 9, 8 ,0 ,0 ,0 ,0 ,6 ,0 } ,
                { 8, 0, 0, 0, 6, 0, 0, 0, 3 } ,
                { 4, 0, 0 ,8 ,0 ,3 ,0 ,0 ,1 } ,
                { 7, 0, 0, 0, 2, 0 ,0 ,0 ,6 } ,
                { 0, 6, 0, 0 ,0 ,0 ,2 ,8 ,0 } ,
                { 0, 0, 0, 4 ,1 ,9, 0 ,0 ,5 } ,
                { 0, 0, 0 ,0 ,8 ,0 ,0 ,7, 9 }
            };

            SudokuSolver(grid, 0, 0, grid.GetLength(0) - 1, grid.GetLength(1) - 1);

            // 4. N Queen
            NQueen(new bool[4, 4], 0, "");

        }

        static void BlockedMaze(int[,] maze, int cr, int cc, int er, int ec, string ans, bool[,] visited)
        {
            if (cr == er && cc == ec)
            {
                Console.WriteLine(ans);
                return;
            }

            if (cr < 0 || cc < 0 || cr > er || cc > ec || maze[cr, cc] == 1 || visited[cr, cc] == true)
            {
                return;
            }

            visited[cr, cc] = true; // as you visit a cell, mark it as visited

            BlockedMaze(maze, cr - 1, cc, er, ec, ans + "T", visited);
            BlockedMaze(maze, cr + 1, cc, er, ec, ans + "D", visited);
            BlockedMaze(maze, cr, cc - 1, er, ec, ans + "L", visited);
            BlockedMaze(maze, cr, cc + 1, er, ec, ans + "R", visited);

            visited[cr, cc] = false;
        }

        static bool WordSearch(char[,] board, int cr, int cc, int er, int ec, string word, int idx, bool[,] visited)
        {
            if (cr < 0 || cc < 0 || cr > er || cc > ec || visited[cr, cc] == true)
            {
                return false;
            }

            if (board[cr, cc] != word[idx])
            {
                return false;
            }

            if (idx == word.Length - 1)
            {
                return true;
            }

            visited[cr, cc] = true;

            bool t = WordSearch(board, cr - 1, cc, er, ec, word, idx + 1, visited);
            bool d = WordSearch(board, cr + 1, cc, er, ec, word, idx + 1, visited);
            bool l = WordSearch(board, cr, cc - 1, er, ec, word, idx + 1, visited);
            bool r = WordSearch(board, cr, cc + 1, er, ec, word, idx + 1, visited);

            visited[cr, cc] = false;

            return t || d || l || r;

        }

        static void SudokuSolver(int[,] board, int cr, int cc, int er, int ec)
        {
            if (cr > er)
            {
                Display(board);
                return;
            }

            if (cc > ec)
            {
                SudokuSolver(board, cr + 1, 0, er, ec);
                return;
            }

            if (board[cr, cc] != 0)
            {
                SudokuSolver(board, cr, cc + 1, er, ec);
                return;
            }

            for (int i = 1; i <= 9; i++)
            {
                if (IsItSafe(board, cr, cc, er, ec, i))
                {
                    board[cr, cc] = i;
                    SudokuSolver(board, cr, cc + 1, er, ec);
                    board[cr, cc] = 0;
                }
            }

        }

        static bool IsItSafe(int[,] board, int cr, int cc, int er, int ec, int val)
        {
            // row
            for (int c = 0; c <= ec; c++)
            {
                if (board[cr, c] == val)
                {
                    return false;
                }
            }

            //col
            for (int r = 0; r <= er; r++)
            {
                if (board[r, cc] == val)
                {
                    return false;
                }
            }

            // 3*3 grid
            int sr = cr - cr % 3;
            int sc = cc - cc % 3;

            for (int r = sr; r < sr + 3; r++)
            {
                for (int c = sc; c < sc + 3; c++)
                {
                    if (board[r, c] == val)
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        static void Display(int[,] board)
        {
            Console.WriteLine("-----------------------");

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("-----------------------");

        }

        static void NQueen(bool[,] board, int row, string ans)
        {

            if(row == board.GetLength(0))
            {
                Console.WriteLine(ans);
                return;
            }

            for(int col = 0; col < board.GetLength(1); col++)
            {
                if (IsItSafeQueen(board, row, col))
                {
                    board[row, col] = true;
                    NQueen(board, row + 1, ans + "{" + row + "-" + col + "}");
                    board[row, col] = false;
                }
            }

        }

        static bool IsItSafeQueen(bool[,] board , int row, int col)
        {
            // up
            int r = row;
            int c = col;

            while(r >= 0)
            {
                if (board[r,c])
                {
                    return false;
                }

                r--;
            }

            // d left
            r = row;
            c = col;

            while (r >= 0 && c >= 0)
            {
                if (board[r, c])
                {
                    return false;
                }

                r--;
                c--;
            }

            // d right
            r = row;
            c = col;

            while (r >= 0 && c < board.GetLength(1))
            {
                if (board[r, c])
                {
                    return false;
                }

                r--;
                c++;
            }

            return true;

        }

    }
}