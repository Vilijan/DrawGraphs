using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Test
{
    class NodesDoc
    {
        public List<Node> nodes;
       
        public NodesDoc()
        {
            nodes = new List<Node>();
            
        }

        private Point findNodes(int node1, int node2)
        {
            Point r = new Point(-1, -1);
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].index == node1 && r.X == -1) r.X = i;
                if (nodes[i].index == node2 && r.Y == -1) r.Y = i;

            }

            return r;
        }

        //private bool edgeIntersection(int cx, int cy, int radius, Point point1, Point point2)
        //{
        //    int dx, dy, A, B, C, det, t;

        //    dx = point2.X - point1.X;
        //    dy = point2.Y - point1.Y;

        //    A = dx * dx + dy * dy;
        //    B = 2 * (dx * (point1.X - cx) + dy * (point1.Y - cy));
        //    C = (point1.X - cx) * (point1.X - cx) + (point1.Y - cy) * (point1.Y - cy) - radius * radius;

        //    det = B * B - 4 * A * C;
        //    if ((det < 0))
        //    {
        //        return false;
        //    }

        //    return true;
        //}


        public void addNode(Point p, int idx, bool w = false)
        {
            nodes.Add(new Node(p, idx,w));
        }

        public bool Connect(int node1, int node2, int weight)
        {
            int n1, n2;
            Point idxs = findNodes(node1, node2);
            n1 = idxs.X;
            n2 = idxs.Y;
            Point start = nodes[n1].center;
            Point end = nodes[n2].center;
            //foreach (Node node in nodes)
            //{
            //    if (node.index == n1 || node.index == n2)
            //        continue;
            //    if (edgeIntersection(node.center.X, node.center.Y, node.radius, start, end))
            //    {
            //        button1.Text = node.index.ToString();
            //        return false;
            //    }
            //}

            nodes[n1].Connect(nodes[n2],weight);
            nodes[n2].Connect(nodes[n1],weight);

            return true;
        }

       public void ChangeEdgeColor(int node1,int node2, Color c)
        {
            int n1, n2;
            Point idxs = findNodes(node1, node2);
            n1 = idxs.X;
            n2 = idxs.Y;
            nodes[n1].ChangeEdgeColor(node2, c);
            nodes[n2].ChangeEdgeColor(node1, c);
        }

        public int Create(Point p,int idx,bool w = false)
        {
            Node toAdd = new Node(p, idx,w);
            int toReturn = canAdd(toAdd);
            if (toReturn == -1)
            {
                nodes.Add(toAdd);
                return -1;
            }
            else
            {
                return toReturn;

            }
            
        }


        int canAdd(Node a)
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                if (Intersect(nodes[i], a)) return nodes[i].index;
            }

            return -1;

        }

        public void ChangeColor(int idx,Color color)
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].index == idx) nodes[i].ChangeColor(color);
            }
        }


        public List<Node> Get_Neighbors(int idx)
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                if(nodes[i].index == idx)
                {
                    return nodes[i].neighbors;
                }
            }
            return new List<Node>();
        }

        public List<int> Get_Weights(int idx)
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].index == idx)
                {
                    return nodes[i].weights;
                }
            }
            return new List<int>();
        }

        public void DrawWeights(Graphics g)
        {
            for (int i = 0; i < nodes.Count; i++) nodes[i].DrawWeights(g);
        }

        public void Insert_Weight_Display(int idx, int w)
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                if(nodes[i].index == idx)
                {
                    nodes[i].weight_to_display = w;
                }
            }
        }

        bool Intersect(Node a, Node b)
        {
            return (a.center.X - b.center.X) * (a.center.X - b.center.X)
                + (a.center.Y - b.center.Y) * (a.center.Y - b.center.Y) <= a.radius * b.radius * 10;
        }



        public void Draw(Graphics g)
        {
            foreach(Node n in nodes)
            {
                n.Draw(g);
            }
        }


        public void Delete(int idx)
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Delete(idx);
            }

            for(int i = 0; i < nodes.Count; i++)
            {
                if(nodes[i].index == idx)
                {
                    nodes.RemoveAt(i);
                    return;
                }
            }

        }

        public void Reset()
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                nodes[i].ChangeColor(Color.Black);
                nodes[i].ChangeEdgeColorAll();
            }
        }
    }
}
