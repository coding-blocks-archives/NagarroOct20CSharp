using System;

namespace BSTDS
{
    public class BST
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

        public void Add(int item)
        {
           root = Add(root, item);
        }

        private Node Add(Node node, int item)
        {
            if(node == null)
            {
                Node nn = new Node(item);
                return nn;
            }

            if(item <= node.data)
            {
                node.left = Add(node.left, item);
            }
            else
            {
                node.right = Add(node.right, item);
            }

            return node;
        }

        public void Display()
        {
            Console.WriteLine("--------------");
            Display(root);
            Console.WriteLine("--------------");
        }

        private void Display(Node node)
        {
            if (node == null)
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

        public void ReplaceWithSumLarger()
        {
            int sum = 0;
            ReplaceWithSumLarger(root, ref sum);

        }

        public void ReplaceWithSumLarger(Node node,ref int sum)
        {
            if(node == null)
            {
                return;
            }

            ReplaceWithSumLarger(node.right, ref sum);

            int temp = node.data;
            node.data = sum;
            sum += temp;

            ReplaceWithSumLarger(node.left, ref sum);

        }
        
    }

    public class Client
    {
        public static void main(string[] args)
        {
            BST bst = new BST();
            bst.Add(50);
            bst.Add(30);
            bst.Add(70);
            bst.Add(20);
            bst.Add(60);

            bst.Display();
            bst.ReplaceWithSumLarger();
            bst.Display();
        }
    }
}
