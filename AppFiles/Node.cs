using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Test
{
    class Node
    {
        public Point center { set; get; } 
        public bool visited { set; get; }
        public int index { set; get; }
        public List<Node> neighbors { set; get; }
        public List<int> weights { set; get; }
        public List<Color> edge_colors { set; get; }
        public int radius = 15;
        public Color color;
        public bool weighted;
        public int weight_to_display;

        public Node(Point p, int idx,bool w=false)
        {
            center = p;
            visited = false;
            index = idx;
            neighbors = new List<Node>();
            color = Color.Black;
            weights = new List<int>();
            weighted = w;
            weight_to_display = -1;
            edge_colors = new List<Color>();
        }


        public void ChangeEdgeColorAll(){
            for(int i=0;i<edge_colors.Count;i++){
                edge_colors[i] = Color.Black;
              }
        }

        public void Connect(Node node, int weight)
        {
            neighbors.Add(node);
            weights.Add(weight);
            edge_colors.Add(Color.Black);
        }

        public void Draw(Graphics g)
        {
            Brush br = new SolidBrush(color);
            g.FillEllipse(br, center.X - radius - 5, center.Y - radius - 5, 2 * radius, 2 * radius);
            br = new SolidBrush(Color.Black);

            for (int i = 0; i < neighbors.Count; i++)
            {
                Pen p = new Pen(edge_colors[i], 3);
                g.DrawLine(p, center.X, center.Y, neighbors[i].center.X, neighbors[i].center.Y);
                if (weighted)
                {
                    Font font = new Font("Arial", 14);
                    Brush br1 = new SolidBrush(Color.White);
                    int x, y;
                    x = (center.X + neighbors[i].center.X) / 2;
                    y = (center.Y + neighbors[i].center.Y) / 2;
                    g.FillEllipse(br1, x, y, 15, 15);
                    g.DrawString(weights[i].ToString(), font, br, x,
                       y);
                    br1.Dispose();
                }
                p.Dispose();
            }

            br.Dispose();
        }


        public void Delete(int idx)
        {
            for(int i = 0; i < neighbors.Count; i++)
            {
                if(neighbors[i].index == idx)
                {
                    neighbors.RemoveAt(i);
                    if (weighted) weights.RemoveAt(i);
                }
            }
        }


        public void ChangeEdgeColor(int idx, Color c)
        {
            for(int i = 0; i < neighbors.Count; i++)
            {
                if(neighbors[i].index == idx)
                {
                    edge_colors[i] = c;
                }
            }
        }

        public void DrawWeights(Graphics g)
        {
            Brush br = new SolidBrush(Color.White);
            Font font = new Font("Arial", 10);
            int size = weight_to_display.ToString().Length;
            g.DrawString(weight_to_display.ToString(), font, br, center.X-4*size, center.Y-radius+5);
            br.Dispose();
        }

        public void ChangeColor(Color c)
        {
            color = c;
        }

    }
}
