using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class UnweightedGraph : Form
    {
        private NodesDoc nodesDoc;
        private int nextIdx;
        private Dictionary<int, bool> visited;
        private List<int> indexes;
        private int x;
        private int y;
        private int width;
        private int height;
        private int selected;
        private Timer timer;
        private Stack<int> stack;
        private Queue<int> queue;
        private bool algorithm_on;
        private bool reset_clear_off;

        public UnweightedGraph()
        {
            InitializeComponent();
           
            this.DoubleBuffered = true;

            init_constructor();

            


        }


        void init_constructor()
        {
            
            nodesDoc = new NodesDoc();
            x = 20;
            y = 60;
            width = this.Width - 3 * x;
            height = this.Height - (int)(2.5 * y);
            selected = -1;
            visited = new Dictionary<int, bool>();
            indexes = new List<int>();
            algorithm_on = false;
            nextIdx = 0;
            reset_clear_off = true;
        }

        void init_visited()
        {
            
            for(int i = 0; i < indexes.Count; i++)
            {
                visited[indexes[i]] = false;

            }
        }

        private void UnweightedGraph_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 3);
            e.Graphics.DrawRectangle(pen, x, y, width,height);
            pen.Dispose();
            nodesDoc.Draw(e.Graphics);
            if (selected != -1)
            {
                if(cbxAlgoritmi.SelectedIndex >= 0 && cbxSpeed.SelectedIndex>=0)
                btnStart.Enabled = true;

                btnDelete.Enabled = true;
            }
            else
            {
                btnStart.Enabled = false;
                btnDelete.Enabled = false;
            }
            if (nodesDoc.nodes.Count > 0 && !reset_clear_off)
            {
                btnClear.Enabled = true;
                btnReset.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
                btnReset.Enabled = false;
            }


        }

        private void UnweightedGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (algorithm_on) return;

            if(e.Location.X >= x+15 && e.Location.X <= x+width - 15)
            {
                if(e.Location.Y >= y + 15 && e.Location.Y <= y + height - 15)
                {
                    int added = nodesDoc.Create(e.Location, nextIdx);
                    
                    if (added == -1)
                    {
                        indexes.Add(nextIdx);
                        nextIdx++;
                        
                    }
                    else
                    {
                        if (selected == -1)
                        {
                            selected = added;
                            nodesDoc.ChangeColor(selected, Color.Red);
                        }
                        else
                        {
                            if (selected != added)
                            {
                                nodesDoc.Connect(selected, added, 1);
                                nodesDoc.ChangeColor(selected, Color.Black);
                                selected = -1;
                            }
                            else
                            {
                                nodesDoc.ChangeColor(selected, Color.Black);
                                selected = -1;

                            }

                        }
                    }

                }
            }

            if (nodesDoc.nodes.Count > 0) reset_clear_off = false;
            else reset_clear_off = true;
            Invalidate(true);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            algorithm_on = true;
            reset_clear_off = true;
            init_visited();
            btnClear.Enabled = false;
            int idx = cbxSpeed.SelectedIndex;

            timer = new Timer();
            timer.Interval = Int32.Parse((string) cbxSpeed.Items[idx]);
            idx = cbxAlgoritmi.SelectedIndex;
            if (cbxAlgoritmi.Items[idx] == "Depth-First Search")
            {
                stack = new Stack<int>();
                stack.Push(selected);
                selected = -1;
                timer.Tick += new EventHandler(dfs);
                timer.Start();
            }
            else
            {
                if(cbxAlgoritmi.Items[idx] == "Breadth-First Search")
                {
                    queue = new Queue<int>();
                    queue.Enqueue(selected);
                    selected = -1;
                    timer.Tick += new EventHandler(bfs);
                    timer.Start();
                }

            }
         
        }

        void bfs(object sender, EventArgs e)
        {
            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();
                if (visited[curr]) continue;
                visited[curr] = true;
                
                List<Node> neighbors = nodesDoc.Get_Neighbors(curr);
                for(int i = 0; i < neighbors.Count; i++)
                {
                    if (!visited[neighbors[i].index]) queue.Enqueue(neighbors[i].index);
                }
                nodesDoc.ChangeColor(curr, Color.Green);
                Invalidate(true);
                return;
            }
            timer.Stop();
            reset_clear_off = false;
            selected = -1;
            Invalidate(true);
        }


        void dfs(object sender, EventArgs e)
        {
            
            while (stack.Count > 0)
            {
                int curr = stack.Pop();
                if (visited[curr]) continue;
                visited[curr] = true;
                List<Node> neighbors = nodesDoc.Get_Neighbors(curr);
                for(int i = 0; i < neighbors.Count; i++)
                {
                   
                    if (!visited[neighbors[i].index])
                    {
                        stack.Push(neighbors[i].index);
                    }
                }
                nodesDoc.ChangeColor(curr, Color.Green);
                Invalidate(true);
                return;
            }
            timer.Stop();
            reset_clear_off = false;
            selected = -1;
            Invalidate(true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            nodesDoc.Reset();
            selected = -1;
            Invalidate(true);
            btnReset.Enabled = false;
            algorithm_on = false;
        }

        private void UnweightedGraph_Resize(object sender, EventArgs e)
        {
            width = this.Width - 3 * x;
            height = this.Height - (int)(2.5 * y);
            int left = this.Width - 330 - 3 * x;
            btnClear.Width = btnReset.Width = btnDelete.Width = btnStart.Width = left / 4;
            btnReset.Location = new Point(btnClear.Location.X + btnClear.Width + 6, btnReset.Location.Y);
            btnDelete.Location = new Point(btnReset.Location.X + btnReset.Width + 6, btnDelete.Location.Y);
            btnStart.Location = new Point(btnDelete.Location.X + btnDelete.Width + 6, btnStart.Location.Y);
            Invalidate(true);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            init_constructor();
            Invalidate(true);
            algorithm_on = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            nodesDoc.Delete(selected);
            indexes.Remove(selected);
            selected = -1;
            if (nodesDoc.nodes.Count > 0) reset_clear_off = false;
            else reset_clear_off = true;
            Invalidate(true);
        }
    }
}
