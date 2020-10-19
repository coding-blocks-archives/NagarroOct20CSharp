using System;
using System.Collections.Generic;

namespace QueueDS
{
    class QueueQs
    {
        public static void main(string[] args)
        {
            int[] arr = { 10, -1, -8, 6, -30, 40, 50, 60 };
            FirstNegativeWindow(arr, 3);
        }

        public static void FirstNegativeWindow(int[] arr, int k)
        {
            Queue<int> q = new Queue<int>();

            for(int i=0; i < k; i++)
            {
                if(arr[i] < 0)
                {
                    q.Enqueue(i);
                }
            }

            for(int i = k; i < arr.Length; i++)
            {
                // result
                if(q.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(arr[q.Peek()]);
                }

                // out of window elements remove
                if(q.Count != 0 && q.Peek() <= i-k)
                {
                    q.Dequeue();
                }

                // insert the ith element
                if(arr[i] < 0)
                {
                    q.Enqueue(i);
                }
            }

            if (q.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(arr[q.Peek()]);
            }


        }
    }
}