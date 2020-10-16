using System;

namespace DP
{
    class DPQs
    {
        static void Main(string[] args)
        {
            int n = 10;

            //Console.WriteLine(FibTD(n, new int[n+1]));
            //Console.WriteLine(FibBU(n));

            //Console.WriteLine(ClimbStairsTD(0, n, new int[n]));
            //Console.WriteLine(ClimbStairsBU(n));

            //Console.WriteLine(MazePathTD(0, 0, n, n , new int[n+1,n+1]));
            //Console.WriteLine(MazePathBU(n, n));

            // int[] arr = { 2, 3, 5, 1, 4 };
            //int[] arr = new int[n];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = i + 1;
            //}
            //Console.WriteLine(WineProblemTD(arr, 0, arr.Length - 1, new int[arr.Length, arr.Length]));
            //Console.WriteLine(WineProblemBU(arr));

            //string s = "abcdefbnvchzvhdbdshv";
            //string p = "a?******************************v";
            //Console.WriteLine(WildcardMatching(s, p));
            //Console.WriteLine(WildcardMatchingTD(s, p, 0, 0, new int[s.Length,p.Length]));
            //Console.WriteLine(WildcardMatchingBU(s, p));

            // Console.WriteLine(UniqueBSTsTD(n , new int[n+1]));
            Console.WriteLine(UniqueBSTsBU(n));


        }

        static int Fib(int n)
        {
            if(n == 0|| n == 1)
            {
                return n;
            }

            int fnm1 = Fib(n - 1);
            int fnm2 = Fib(n - 2);

            int fn = fnm1 + fnm2;

            return fn;

        }

        static int FibTD(int n, int[] strg)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            if (strg[n] != 0) // re-use
            {
                return strg[n];
            }

            int fnm1 = FibTD(n - 1, strg);
            int fnm2 = FibTD(n - 2, strg);

            int fn = fnm1 + fnm2;

            strg[n] = fn ; // store

            return fn;

        }

        static int FibBU(int n)
        {
            int[] strg = new int[n + 1];

            strg[0] = 0;
            strg[1] = 1;

            for(int i = 2; i < strg.Length; i++)
            {
                strg[i] = strg[i - 1] + strg[i - 2];
            }

            return strg[n];

        }

        static int ClimbStairs(int curr, int n)
        {
            // positive base case
            if (curr == n)
            {
                return 1;
            }

            // negative base case
            if (curr > n)
            {
                return 0;
            }

            int o1 = ClimbStairs(curr + 1, n);
            int o2 = ClimbStairs(curr + 2, n);
            int o3 = ClimbStairs(curr + 3, n);

            int res = o1 + o2 + o3;

            return res;

        }

        static int ClimbStairsTD(int curr, int n, int[] strg)
        {
            // positive base case
            if (curr == n)
            {
                return 1;
            }

            // negative base case
            if (curr > n)
            {
                return 0;
            }

            if (strg[curr] != 0)
            {
                return strg[curr];
            }

            int o1 = ClimbStairsTD(curr + 1, n, strg);
            int o2 = ClimbStairsTD(curr + 2, n, strg);
            int o3 = ClimbStairsTD(curr + 3, n, strg);

            int res = o1 + o2 + o3;

            strg[curr] = res;

            return res;

        }

        static int ClimbStairsBU(int n)
        {
            int[] strg = new int[n + 3];

            strg[n] = 1;

            for(int i = n-1; i >=0; i--)
            {
                strg[i] = strg[i + 1] + strg[i + 2] + strg[i + 3];
            }

            return strg[0];

        }

        static int MazePath(int cr, int cc, int er, int ec)
        {
            // pbc
            if (cr == er && cc == ec)
            {
                return 1;
            }

            // nbc
            if (cr > er || cc > ec)
            {
                return 0;
            }

            int ch = MazePath(cr, cc + 1, er, ec);
            int cv = MazePath(cr + 1, cc, er, ec);

            return ch + cv;

        }

        static int MazePathTD(int cr, int cc, int er, int ec, int[,] strg)
        {
            // pbc
            if (cr == er && cc == ec)
            {
                return 1;
            }

            // nbc
            if (cr > er || cc > ec)
            {
                return 0;
            }

            if(strg[cr,cc] != 0)
            {
                return strg[cr, cc];
            }

            int ch = MazePathTD(cr, cc + 1, er, ec, strg);
            int cv = MazePathTD(cr + 1, cc, er, ec, strg);

            strg[cr, cc] = ch + cv;

            return ch + cv;

        }

        static int MazePathBU(int er, int ec)
        {

            int[,] strg = new int[er + 2, ec + 2];

            for(int r = er; r >=0; r--)
            {
                for(int c = ec; c >=0; c--)
                {
                    if (r == er && c == ec)
                    {
                        strg[r, c] = 1;
                    }
                    else
                    {
                        strg[r, c] = strg[r, c + 1] + strg[r + 1, c];
                    }
                }
            }

            return strg[0,0];
        }

        static int WineProblem(int[] arr , int si , int ei, int yr)
        {
            if(si == ei)
            {
                return arr[si] * yr;
            }

            int left = WineProblem(arr, si + 1, ei, yr + 1) + arr[si]*yr;
            int right = WineProblem(arr, si, ei-1, yr + 1) + arr[ei] * yr;

            int res = Math.Max(left, right);

            return res;
        }

        static int WineProblemTD(int[] arr, int si, int ei, int[,] strg)
        {
            int yr = arr.Length - (ei - si + 1) + 1;

            if (si == ei)
            {
                return arr[si] * yr;
            }

            if (strg[si,ei] != 0)
            {
                return strg[si,ei];
            }

            int left = WineProblemTD(arr, si + 1, ei, strg) + arr[si] * yr;
            int right = WineProblemTD(arr, si, ei - 1, strg) + arr[ei] * yr;

            int res = Math.Max(left, right);

            strg[si, ei] = res;

            return res;
        }

        static int WineProblemBU(int[] arr)
        {
            int n = arr.Length;
            int[,] strg = new int[n, n];

            for(int slide = 0; slide <= n-1; slide++)
            {
                for(int si = 0; si <= n-slide-1; si++)
                {
                    int ei = si + slide;

                    // copy
                    int yr = n - (ei - si + 1) + 1;

                    if (si == ei)
                    {
                        strg[si, ei] = arr[si] * yr;
                    }
                    else
                    { 

                        int left = strg[si + 1, ei] + arr[si] * yr;
                        int right = strg[si, ei - 1] + arr[ei] * yr;

                        int res = Math.Max(left, right);

                        strg[si, ei] = res;

                    }

                }

            }

            return strg[0,n-1];


        }

        static bool WildcardMatching(string src, string pat)
        {
            if(src.Length == 0 && pat.Length == 0)
            {
                return true;
            }

            if(src.Length !=0 && pat.Length == 0)
            {
                return false;
            }

            if(src.Length==0 && pat.Length != 0)
            {
                for(int i=0; i< pat.Length; i++)
                {
                    if(pat[i] != '*')
                    {
                        return false;
                    }
                }

                return true;
            }

            char chs = src[0];
            char chp = pat[0];

            string ros = src.Substring(1);
            string rop = pat.Substring(1);

            bool res;

            if(chs ==chp || chp == '?')
            {
                res = WildcardMatching(ros, rop);
            }
            else if(chp == '*')
            {
                bool blank = WildcardMatching(src, rop);
                bool multiple = WildcardMatching(ros, pat);

                res = blank || multiple;
            }
            else
            {
                res = false;
            }

            return res;
        }


        static bool WildcardMatching(string src, string pat, int svidx, int pvidx)
        {
            if (src.Length == svidx && pat.Length == pvidx)
            {
                return true;
            }

            if (src.Length != svidx && pat.Length == pvidx)
            {
                return false;
            }

            if (src.Length == svidx && pat.Length != pvidx)
            {
                for (int i = pvidx; i < pat.Length; i++)
                {
                    if (pat[i] != '*')
                    {
                        return false;
                    }
                }

                return true;
            }

            char chs = src[svidx];
            char chp = pat[pvidx];

            bool res;

            if (chs == chp || chp == '?')
            {
                res = WildcardMatching(src, pat, svidx+1, pvidx+1);
            }
            else if (chp == '*')
            {
                bool blank = WildcardMatching(src, pat, svidx, pvidx+1);
                bool multiple = WildcardMatching(src, pat, svidx+1, pvidx);

                res = blank || multiple;
            }
            else
            {
                res = false;
            }

            return res;
        }

        static bool WildcardMatchingTD(string src, string pat, int svidx, int pvidx, int[,] strg)
        {
            if (src.Length == svidx && pat.Length == pvidx)
            {
                return true;
            }

            if (src.Length != svidx && pat.Length == pvidx)
            {
                return false;
            }

            if (src.Length == svidx && pat.Length != pvidx)
            {
                for (int i = pvidx; i < pat.Length; i++)
                {
                    if (pat[i] != '*')
                    {
                        return false;
                    }
                }

                return true;
            }

            if(strg[svidx, pvidx] != 0)
            {
                return (strg[svidx, pvidx] == 1) ? false : true;
            }

            char chs = src[svidx];
            char chp = pat[pvidx];

            bool res;

            if (chs == chp || chp == '?')
            {
                res = WildcardMatchingTD(src, pat, svidx + 1, pvidx + 1, strg);
            }
            else if (chp == '*')
            {
                bool blank = WildcardMatchingTD(src, pat, svidx, pvidx + 1, strg);
                bool multiple = WildcardMatchingTD(src, pat, svidx + 1, pvidx, strg);

                res = blank || multiple;
            }
            else
            {
                res = false;
            }

            strg[svidx,pvidx] =  (res ? 2: 1) ;

            return res;
        }

        static bool WildcardMatchingBU(string src, string pat)
        {
            bool[,] strg = new bool[src.Length + 1, pat.Length + 1];

            strg[src.Length, pat.Length] = true;

            for(int r = src.Length; r>=0; r--)
            {
                for(int c = pat.Length-1; c>=0; c--)
                {
                    // last row fill : bc
                    if(r == src.Length)
                    {
                        if(pat[c] == '*')
                        {
                            strg[r,c] = strg[r,c + 1];
                        }
                        else
                        {
                            strg[r, c] = false;
                        }
                    }
                    else
                    {
                        char chs = src[r];
                        char chp = pat[c];

                        bool res;

                        if (chs == chp || chp == '?')
                        {
                            res = strg[r + 1, c + 1];
                        }
                        else if (chp == '*')
                        {
                            bool blank = strg[r, c + 1];
                            bool multiple = strg[r + 1, c];

                            res = blank || multiple;
                        }
                        else
                        {
                            res = false;
                        }

                        strg[r, c] = res;

                    }

                }
            }

            return strg[0, 0];

        }

        static int UniqueBSTs(int n)
        {
            if (n <= 1)
                return 1;

            int total = 0;

            for(int i = 1; i <= n; i++)
            {
                int left = UniqueBSTs(i - 1);
                int right = UniqueBSTs(n - i);

                int res = left * right;

                total += res;

            }

            return total;
        }

        static int UniqueBSTsTD(int n, int[] strg)
        {
            if (n <= 1)
                return 1;

            if (strg[n] != 0)
            {
                return strg[n];
            }

            int total = 0;

            for (int i = 1; i <= n; i++)
            {
                int left = UniqueBSTsTD(i - 1, strg);
                int right = UniqueBSTsTD(n - i, strg);

                int res = left * right;

                total += res;

            }

            strg[n] = total; 

            return total;
        }

        static int UniqueBSTsBU(int tn)
        {

            int[] strg = new int[tn + 1];

            strg[0] = 1;
            strg[1] = 1;

            for (int n = 2; n <= tn; n++)
            {
                int total = 0;

                for (int i = 1; i <= n; i++)
                {
                    int left = strg[i - 1];
                    int right = strg[n - i];

                    int res = left * right;

                    total += res;

                }

                strg[n] = total;

            }

            return strg[tn];

        }
    }
}