using System;
using System.Collections;

namespace NagarroTraining.LLBT
{
    public class HashTableDS
    {
        public static void main(string[] args)
        {

            // create
            Hashtable table = new Hashtable();

            // add
            table.Add(1, "Aman");
            table.Add(2, "Rohit");
            table.Add(3, "Neha");
            table.Add(4, "Riya");

            // get
            string res = (string) table[2];
            Console.WriteLine(res);

            // update
            table[2] = "Mohit";
            string r = (string)table[2];
            Console.WriteLine(r);

            // display
            foreach(int key in table.Keys)
            {
                Console.WriteLine(key + " -> " + table[key]);
            }

            // remove
            //table.Remove(2);
            //foreach (int key in table.Keys)
            //{
            //    Console.WriteLine(key + " -> " + table[key]);
            //}

            //
            // table.Add(2, "Sham");

            // containskey
            Console.WriteLine(table.ContainsKey(2));

            int[] arr = { 2, 12, 9, 16, 10, 5, 3, 20, 25, 11, 1, 8, 6 , 4};
            LongestConsecutiveSeq(arr);
        }

        public static void LongestConsecutiveSeq(int[] arr)
        {
            Hashtable table = new Hashtable();

            foreach(int val in arr)
            {
                if (table.ContainsKey(val - 1))
                {
                    table.Add(val, false);
                }
                else
                {
                    table.Add(val, true);
                }

                if (table.ContainsKey(val + 1))
                {
                    table[val + 1] = false;
                }
            }

            int maxLength = 0;
            int starting = 0;

            foreach(int key in table.Keys)
            {
                if ((bool)table[key])
                {
                    int count = 0;

                    while (table.ContainsKey(key + count))
                    {
                        count++;
                    }

                    if(count > maxLength)
                    {
                        starting = key;
                        maxLength = count;
                    }


                }

            }

            for(int i=0; i < maxLength; i++)
            {
                Console.Write(starting + i + " ");  
            }

            Console.WriteLine();


        }
    }
}
