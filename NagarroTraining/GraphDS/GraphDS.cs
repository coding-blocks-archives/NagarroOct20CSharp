using System;
using System.Collections.Generic;

namespace GraphDS
{
    public class Graph
    {
        public class Pair
        {
            public int nbr;
            public int wt;

            public Pair(int nbr , int wt)
            {
                this.nbr = nbr;
                this.wt = wt;
            }

        }

        LinkedList<Pair>[] al; // info graph
        int V; // no. of vertices

        public Graph(int V)
        {
            al = new LinkedList<Pair>[V];
            this.V = V;

            for(int i=0; i < al.Length; i++)
            {
                al[i] = new LinkedList<Pair>();
            }
        }

        public void AddEdge(int u , int v , int wt)
        {
            Pair fp = new Pair(v, wt);
            al[u].AddLast(fp);

            //Pair sp = new Pair(u, wt);
            //al[v].AddLast(sp);

        }

        public void Display()
        {

            for(int i=0; i < V; i++)
            {
                Console.Write(i + " -> ");

                foreach(Pair p in al[i])
                {
                    Console.Write(p.nbr + "[" + p.wt + "]" + " ");
                }
                Console.WriteLine();
            }
        }

        public int CostVertex(int u , int v)
        {
            foreach(Pair p in al[u])
            {
                if(p.nbr == v)
                {
                    return p.wt;
                }
            }

            return 0;
        }

        public void BFT()
        {
            bool[] visited = new bool[V];
            Queue<int> q = new Queue<int>();

            for (int i = 0; i < V; i++)
            {
                if (visited[i])
                    continue;
                
                q.Enqueue(i);
                visited[i] = true;

                while (q.Count != 0)
                {
                    int re = q.Dequeue();

                    Console.Write(re + " ");

                    foreach (Pair p in al[re])
                    {
                        if (!visited[p.nbr])
                        {
                            q.Enqueue(p.nbr);
                            visited[p.nbr] = true;
                        }
                    }


                }
            }

            Console.WriteLine();

        }

        public void DFT()
        {
            bool[] visited = new bool[V];
            Stack<int> s = new Stack<int>();

            for (int i = 0; i < V; i++)
            {
                if (visited[i])
                    continue;

                s.Push(i);
                visited[i] = true;

                while (s.Count != 0)
                {
                    int re = s.Pop();

                    Console.Write(re + " ");

                    foreach (Pair p in al[re])
                    {
                        if (!visited[p.nbr])
                        {
                            s.Push(p.nbr);
                            visited[p.nbr] = true;
                        }
                    }


                }
            }

            Console.WriteLine();

        }

        public int MinCost(int[] cost , bool[] added)
        {
            int min = Int32.MaxValue;
            int minidx = -1;

            for(int i=0; i < cost.Length; i++)
            {
                if(cost[i] < min && !added[i])
                {
                    min = cost[i];
                    minidx = i;

                }
            }

            return minidx;
        }

        public void Prims(int src)
        {
            bool[] added = new bool[V];
            int[] parent = new int[V];
            int[] cost = new int[V];

            for(int i = 0;i < V; i++)
            {
                cost[i] = Int32.MaxValue;
            }

            parent[src] = -1;
            cost[src] = 0;

            for(int i = 0; i < V; i++)
            {

                int u = MinCost(cost, added);

                added[u] = true;

                foreach(Pair p in al[u])
                {
                    int v = p.nbr;
                    int wt = p.wt;

                    if (!added[v] && cost[v] > CostVertex(u,v))
                    {
                        cost[v] = CostVertex(u, v);
                        parent[v] = u;
                    }
                }

            }

            for(int i=0; i < V; i++)
            {
                Console.WriteLine(parent[i] + " -> " + i + " @ " + cost[i]);
            }

        }

        public void Dijkstra(int src)
        {
            bool[] added = new bool[V];
            int[] cost = new int[V];

            for (int i = 0; i < V; i++)
            {
                cost[i] = Int32.MaxValue;
            }

            cost[src] = 0;

            for (int i = 0; i < V; i++)
            {

                int u = MinCost(cost, added);

                added[u] = true;

                foreach (Pair p in al[u])
                {
                    int v = p.nbr;
                    int wt = p.wt;

                    if (!added[v] && cost[v] > cost[u] + CostVertex(u, v))
                    {
                        cost[v] = cost[u] + CostVertex(u, v);
                    }
                }

            }

            for (int i = 0; i < V; i++)
            {
                Console.WriteLine(src + " -> " + i + " @ " + cost[i]);
            }

        }

        public class EdgePair
        {
            public int u;
            public int v;
            public int wt;

            public EdgePair(int v1 , int v2 , int wt)
            {
                this.u = v1;
                this.v = v2;
                this.wt = wt;
            }
        }

        public List<EdgePair> GetAllEdges()
        {
            List<EdgePair> edges = new List<EdgePair>();

            for (int i=0; i < V; i++)
            {
                foreach(Pair p in al[i])
                {
                    EdgePair np = new EdgePair(i, p.nbr, p.wt);
                    edges.Add(np);
                }
            }

            return edges;
        }

        public void BellmanFord(int src)
        {
            int[] cost = new int[V];
            List<EdgePair> edges = GetAllEdges();

            for(int i=0; i < V; i++)
            {
                cost[i] = 100000;
            }

            cost[src] = 0;

            for(int i=1; i <= V; i++)
            {
                foreach(EdgePair ep in edges)
                {
                    int oc = cost[ep.v];
                    int nc = cost[ep.u] + CostVertex(ep.u, ep.v);

                    if(nc < oc)
                    {
                        if(i <= V-1)
                            cost[ep.v] = nc;
                        else
                        {
                            Console.WriteLine("-ve wt cycle");
                            return;
                        }
                    }
                }
            }

            // print
            for(int i= 0; i< V; i++)
            {
                Console.WriteLine(i + " -> " + cost[i]);
            }
        }


    }

    public class Client
    {
        public static void Main(string[] args)
        {
            Graph g = new Graph(5);

            //g.AddEdge(0, 1, 2);
            //g.AddEdge(0, 3, 6);
            //g.AddEdge(1, 2, 3);
            //g.AddEdge(2, 3, 1);
            //g.AddEdge(3, 4, 4);
            //g.AddEdge(4, 5, 5);
            //g.AddEdge(4, 6, 6);
            //g.AddEdge(5, 6, 7);


            g.AddEdge(0, 1, 8);
            g.AddEdge(0, 2, 4);
            g.AddEdge(0, 3, 5);
            g.AddEdge(2, 3, -3);
            g.AddEdge(1, 4, 2);
            g.AddEdge(4, 1, -3);
            g.AddEdge(3, 4, 4);

            g.Display();

            //g.DFT();
            //g.Prims(0);
            //g.Dijkstra(0);
            g.BellmanFord(0);
        }
    }
}
