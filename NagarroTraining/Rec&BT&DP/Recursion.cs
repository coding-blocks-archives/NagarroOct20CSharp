using System;

namespace Recursion
{
    class RecursionQs
    {
        static void main(string[] args)
        {
            // PDI(3);
            // CoinToss(4, "");
            // ClimbStairs(0, 5, "");
            Console.WriteLine("--------------");
            // MazePath(0, 0, 2, 2, "");
            // ValidParenthesis(0, 0, 3, "");
            PalindromicPartitions("nitin", "");
        }

        static void PDI(int n)
        {
            if (n == 0)
                return;

            Console.WriteLine("hii " + n);
            PDI(n-1);
            Console.WriteLine("bye " + n);
        }

        static void CoinToss(int n , String ans)
        {
            if(n == 0)
            {
                Console.WriteLine(ans);
                return;
            }

            CoinToss(n - 1, ans + "H");
            CoinToss(n - 1, ans + "T");
        }

        static void ClimbStairs(int curr , int n , String ans)
        {
            // positive base case
            if(curr == n)
            {
                Console.WriteLine(ans);
                return;
            }

            // negative base case
            if(curr > n)
            {
                return;
            }

            //ClimbStairs(curr + 1, n, ans + "1");
            //ClimbStairs(curr + 2, n, ans + "2");
            //ClimbStairs(curr + 3, n, ans + "3");

            for(int jump = 1; jump <= 3; jump++)
            {
                ClimbStairs(curr + jump, n, ans + jump);
            }

        }

        static void MazePath(int cr, int cc, int er, int ec, String ans)
        {
            // pbc
            if(cr == er && cc == ec)
            {
                Console.WriteLine(ans);
                return;
            }

            //// nbc
            //if(cr > er || cc > ec)
            //{
            //    return;
            //}

            if(cc+1 <= ec)
                MazePath(cr, cc + 1, er, ec, ans + "H");

            if(cr+1<= er)
                MazePath(cr + 1, cc, er, ec, ans + "V");

        }

        static void ValidParenthesis(int open, int close, int n , String ans)
        {
            if(open == n && close ==n)
            {
                Console.WriteLine(ans);
                return;
            }

            if(open > n || close > open)
            {
                return;
            }

            ValidParenthesis(open + 1, close, n, ans + "(");
            ValidParenthesis(open, close + 1, n, ans + ")");

        }

        static void PalindromicPartitions(String ques, String ans)
        {
            if(ques.Length == 0)
            {
                Console.WriteLine(ans);
                return;
            }

            for(int i = 1; i <= ques.Length; i++)
            {
                String part = ques.Substring(0, i);
                String roq = ques.Substring(i);

                if(IsPalindrome(part))
                    PalindromicPartitions(roq, ans + part + " ");
            }
        }

        static bool IsPalindrome(String str)
        {
            int i = 0;
            int j = str.Length - 1;

            while(i < j)
            {
                if(str[i] != str[j])
                {
                    return false;
                }

                i++;
                j--;
            }

            return true;
        }
      

    }

}