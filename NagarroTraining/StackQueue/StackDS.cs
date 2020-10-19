using System;
using System.Collections.Generic;

namespace StackDS
{
    public class StackQs
    {
       static void Main(string[] args)
       {
            //int[] arr = {80,50,70,30,20,40,90,10,5,35 };
            //int[] res = StockSpan(arr);
            //foreach(int val  in res)
            //{
            //    Console.Write(val + " ");
            //}

            //int[,] arr = { { 0,1,1,1} , {1,0,1,0 } , {1,0,0,0 } , {1,1,1,0 } };
            //CelebrityProblem(arr);

            MyStack s = new MyStack();
            s.push(10);
            s.push(20);
            s.push(3);
            Console.WriteLine(s.peek());
       }

        static int[] StockSpan(int[] arr)
        {
            int[] ans = new int[arr.Length];
            Stack<int> s = new Stack<int>();

            for(int i=0; i< arr.Length; i++)
            {
                while(s.Count > 0 && arr[i] > arr[s.Peek()])
                {
                    s.Pop();
                }

                if(s.Count == 0)
                {
                    ans[i] = i + 1;
                }
                else
                {
                    ans[i] = i - s.Peek();
                }

                s.Push(i);
            }

            return ans;


        }

        static void CelebrityProblem(int[,] arr)
        {

            Stack<int> s = new Stack<int>();

            for(int i=0; i < arr.GetLength(0); i++)
            {
                s.Push(i);
            }

            while(s.Count != 1)
            {
                int a = s.Pop();
                int b = s.Pop();

                // a doesnot know b : b can't be a celeb
                if(arr[a,b] == 0)
                {
                    s.Push(a);
                }
                // a knows b : a can't be a celeb
                else
                {
                    s.Push(b);
                }
            }

            int candidate = s.Pop();

            for(int i =0; i < arr.GetLength(0); i++)
            {
                if (i != candidate)
                {
                    if (arr[i, candidate] == 0 || arr[candidate, i] == 1)
                    {
                        Console.WriteLine("No Celeb");
                        return;
                    }
                }
            }

            Console.WriteLine(candidate);
        }

        class MyStack
        {
            Stack<int> s = new Stack<int>();
            int min = 0;

            public void push(int val)
            {
                if(s.Count == 0)
                {
                    s.Push(val);
                    min = val;
                }
                else if(val >= min)
                {
                        s.Push(val);
                }
                else
                {
                    // encrypt
                    s.Push(2 * val - min);
                    min = val;
                }

            }

            public int peek()
            {
                if(s.Count == 0)
                {
                    Console.WriteLine("Stack is Empty");
                    return -1;
                }
                else if(s.Peek() < min) // encypted form
                {
                    return min;
                }
                else
                {
                    return s.Peek();
                }
            }

            public int pop()
            {
                if (s.Count == 0)
                {
                    Console.WriteLine("Stack is Empty");
                    return -1;
                }
                else if (s.Peek() < min) // encypted form
                {
                    int ov = min;

                    int TopMostStackElement = s.Pop();
                    min =  2 * min - (TopMostStackElement);

                    return ov;
                }
                else
                {
                    return s.Pop();
                }

            }

            public int minimum()
            {
                return min;
            }
        }

    }
}
