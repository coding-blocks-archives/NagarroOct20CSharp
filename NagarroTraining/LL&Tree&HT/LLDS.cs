using System;

namespace LLDS
{
    public class LL
    {
        public class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
            }
        }

        public Node head;

        public void CreateLLIntersection()
        {
            Node n1 = new Node(10);
            Node n2 = new Node(20);
            Node n3 = new Node(30);
            Node n4 = new Node(40);
            Node n5 = new Node(50);
            Node n6 = new Node(60);
            Node n7 = new Node(70);
            Node n8 = new Node(80);
            Node n9 = new Node(90);
            Node n10 = new Node(100);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = n6;
            n6.next = n7;
            n7.next = n8;
            n8.next = n9;
            n9.next = n10;
            n10.next = null;

            Node n11 = new Node(110);
            Node n12 = new Node(120);
            Node n13 = new Node(130);

            n11.next = n12;
            n12.next = n13;
            n13.next = n7;

            Node h1 = n1;
            Node h2 = n11;

            Intersection(h1, h2);

        }

        public void Intersection(Node h1, Node h2)
        {
            Node fp = h1;
            Node sp = h2;

            while(fp != sp)
            {
                if (fp == null)
                {
                    fp = h2;
                }
                else
                {
                    fp = fp.next;
                }

                if (sp == null)
                {
                    sp = h1;
                }
                else
                {
                    sp = sp.next;
                }

            }

            Console.WriteLine( fp.data);
        }

        public void CreateLLKReverse(int k)
        {
            Node n1 = new Node(10);
            Node n2 = new Node(20);
            Node n3 = new Node(30);
            Node n4 = new Node(40);
            Node n5 = new Node(50);
            Node n6 = new Node(60);
            Node n7 = new Node(70);
            Node n8 = new Node(80);
           // Node n9 = new Node(90);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = n6;
            n6.next = n7;
            n7.next = n8;
            n8.next = null;
           // n9.next = null;

            head = KReverse(n1, k);
        }

        public Node KReverse(Node node, int k)
        {
            if(node == null)
            {
                return null;
            }

            // smaller problem : reverse s2 and s3
            Node temp = node;

            for(int i=1; i <= k  && temp != null; i++)
            {
                temp = temp.next;
            }

            Node prev = KReverse(temp, k);

            // self work : to reverse set 1
            Node curr = node;

            while (curr != temp)
            {
                Node ahead = curr.next;
                curr.next = prev;

                prev = curr;
                curr = ahead;
            }

            return prev;
        }

        public void Display()
        {
            Node temp = head;
            while(temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }

            Console.WriteLine();

        }
    }

    public class Client
    {
        public static void main(string[] args)
        {
            LL list = new LL();
            // list.CreateLLIntersection();
            list.CreateLLKReverse(3);
            list.Display();
        }
    }
}