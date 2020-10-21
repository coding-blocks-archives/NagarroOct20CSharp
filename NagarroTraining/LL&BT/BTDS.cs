using System;
using System.Collections.Generic;

namespace BTDS
{
    public class BT
    {
        public class Node
        {
            public int data;
            public Node left;
            public Node right;

            public Node(int data)
            {
                this.data = data;
            }
        }

        public Node root;

        public void TakeInput()
        {
            Queue<Node> q = new Queue<Node>();

            int val = Convert.ToInt32(Console.ReadLine());
            root = new Node(val);
            q.Enqueue(root);

            while(q.Count != 0)
            {
                Node pn = q.Dequeue();

                int ld = Convert.ToInt32(Console.ReadLine());

                if(ld != -1)
                {
                    Node ln = new Node(ld);
                    pn.left = ln;
                    q.Enqueue(ln);
                }

                int rd = Convert.ToInt32(Console.ReadLine());

                if (rd != -1)
                {
                    Node rn = new Node(rd);
                    pn.right = rn;
                    q.Enqueue(rn);
                }
            }

        }

        public void Display()
        {
            Display(root);
        }

        private void Display(Node node)
        {
            if(node == null)
            {
                return;
            }

            // self work
            String str = "";

            if (node.left == null)
                str += ".";
            else
                str += node.left.data;

            str += " -> " + node.data + " <- ";

            if (node.right == null)
                str += ".";
            else
                str += node.right.data;

            Console.WriteLine(str);

            // smaller problem
            Display(node.left);
            Display(node.right);

        }

        public int Ht()
        {
            return Ht(root);
        }

        private int Ht(Node node)
        {
            if(node == null)
            {
                return -1;
            }

           int lh = Ht(node.left);
           int rh =  Ht(node.right);

           int level = Math.Max(lh, rh);

           return level + 1;
        }

        public bool IsBalanced()
        {
            return IsBalanced(root);
        }

        private bool IsBalanced(Node node)
        {
            if(node == null)
            {
                return true;
            }

            bool lb = IsBalanced(node.left);
            bool rb = IsBalanced(node.right);

            int bf = Ht(node.left) - Ht(node.right);

            if(lb && rb && (bf == -1 || bf == 0 || bf == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool FlipEquivalent(BT other)
        {
            return FlipEquivalent(this.root, other.root);
        }

        private bool FlipEquivalent(Node X, Node Y)
        {
            if(X == null && Y == null)
            {
                return true;
            }

            if(X==null || Y == null || X.data != Y.data)
            {
                return false;
            }

            bool flip = FlipEquivalent(X.left, Y.right) && FlipEquivalent(X.right, Y.left);

            if (flip)
                return true;

            bool notFlip = FlipEquivalent(X.left, Y.left) && FlipEquivalent(X.right, Y.right);

            return flip || notFlip;
        }
    }

    public class ClientBT
    {
        public static void main(string[] args)
        {
            BT bt = new BT();
            bt.TakeInput();
            bt.Display();
            Console.WriteLine(bt.Ht());

            BT bt2 = new BT();
            bt2.TakeInput();

            Console.WriteLine(bt.FlipEquivalent(bt2));
        }
    }
}
