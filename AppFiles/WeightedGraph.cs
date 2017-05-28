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
    public partial class WeightedGraph : Form
    {
        private NodesDoc nodesDoc;
        private int nextIdx;
        private Dictionary<int, bool> visited;
        private Dictionary<int, int> distance;
        private List<int> indexes;
        private SimplePriorityQueue<SimpleNode> pq;
        private int x;
        private int y;
        private int width;
        private int height;
        private int selected;
        private Timer timer;
        private bool algorithm_on;
        private bool reset_clear_off;
        private bool is_running;

        public WeightedGraph()
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
            distance = new Dictionary<int, int>();
            indexes = new List<int>();
            algorithm_on = false;
            nextIdx = 0;
            reset_clear_off = true;
            is_running = true;
        }
        
        void init_visited()
        {

            for (int i = 0; i < indexes.Count; i++)
            {
                visited[indexes[i]] = false;
                distance[indexes[i]] = -1;
            }
        }

        private void WeightedGraph_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 3);
            e.Graphics.DrawRectangle(pen, x, y, width, height);
            pen.Dispose();
            nodesDoc.Draw(e.Graphics);
            if (selected != -1)
            {
                if (cbxAlgoritmi.SelectedIndex >= 0 && cbxSpeed.SelectedIndex >= 0)
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
            if (!is_running) nodesDoc.DrawWeights(e.Graphics);
        }

        private void WeightedGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (algorithm_on) return;

            if (e.Location.X >= x + 15 && e.Location.X <= x + width - 15)
            {
                if (e.Location.Y >= y + 15 && e.Location.Y <= y + height - 15)
                {
                    int added = nodesDoc.Create(e.Location, nextIdx,true);

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
                                InputWeight inputWeight = new InputWeight();
                                if (inputWeight.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    nodesDoc.Connect(selected, added, inputWeight.weight);
                                    nodesDoc.ChangeColor(selected, Color.Black);
                                    selected = -1;
                                }

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

        private void btnReset_Click(object sender, EventArgs e)
        {
                nodesDoc.Reset();
                selected = -1;
                is_running = true;
                Invalidate(true);
                btnReset.Enabled = false;
                algorithm_on = false;
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
            is_running = true;
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
            timer.Interval = Int32.Parse((string)cbxSpeed.Items[idx]);
            idx = cbxAlgoritmi.SelectedIndex;
            pq = new SimplePriorityQueue<SimpleNode>();
            SimpleNode toAdd = new SimpleNode(selected, 0);
            pq.Enqueue(toAdd, 0);
            selected = -1;
            if (cbxAlgoritmi.Items[idx] == "Dijkstra")
            {
                timer.Tick += new EventHandler(dijkstra);
                timer.Start();
            }
            else
            {        
                timer.Tick += new EventHandler(prim);
                timer.Start();
            }
        }

        void dijkstra(object sender,EventArgs e)
        {
            while(pq.Count > 0)
            {
                SimpleNode curr = pq.Dequeue();
                if (visited[curr.idx]) continue;
                visited[curr.idx] = true;
                distance[curr.idx] = curr.weight;
                List<int> weights = nodesDoc.Get_Weights(curr.idx);
                List<Node> neighbors = nodesDoc.Get_Neighbors(curr.idx);

                for(int i = 0; i < neighbors.Count; i++)
                {
                    if (!visited[neighbors[i].index])
                    {
                        SimpleNode toAdd = new SimpleNode(neighbors[i].index, curr.weight + weights[i]);
                        pq.Enqueue(toAdd, toAdd.weight);
                    }
                }

                nodesDoc.ChangeColor(curr.idx, Color.Green);
                Invalidate(true);
                return;
            }

            timer.Stop();
            reset_clear_off = false;
            selected = -1;
            for(int i = 0; i < indexes.Count; i++)
            {
                nodesDoc.Insert_Weight_Display(indexes[i], distance[indexes[i]]);
            }

            is_running = false;
            Invalidate(true);
        }


        void prim(object sender,EventArgs e)
        {
            while(pq.Count > 0)
            {
                SimpleNode curr = pq.Dequeue();
                if (visited[curr.idx]) continue;
                visited[curr.idx] = true;
                List<int> weights = nodesDoc.Get_Weights(curr.idx);
                List<Node> neighbors = nodesDoc.Get_Neighbors(curr.idx);

                for (int i = 0; i < neighbors.Count; i++)
                {
                    if (!visited[neighbors[i].index])
                    {
                        SimpleNode toAdd = new SimpleNode(neighbors[i].index, curr.weight + weights[i]);
                        toAdd.prev = curr.idx;
                        pq.Enqueue(toAdd, toAdd.weight);
                    }
                }
                if (curr.prev != -1)
                {
                    nodesDoc.ChangeEdgeColor(curr.idx, curr.prev, Color.Blue);
                    Invalidate(true);
                    return;
                }
                
            }
            timer.Stop();
            reset_clear_off = false;
            selected = -1;
            Invalidate(true);
        }

        private void WeightedGraph_Resize(object sender, EventArgs e)
        {
            width = this.Width - 3 * x;
            height = this.Height - (int)(2.5 * y);
            int left = this.Width - 325 - 3 * x;
            btnClear.Width = btnReset.Width = btnDelete.Width = btnStart.Width = left / 4;
            btnReset.Location = new Point(btnClear.Location.X + btnClear.Width + 6, btnReset.Location.Y);
            btnDelete.Location = new Point(btnReset.Location.X + btnReset.Width + 6, btnDelete.Location.Y);
            btnStart.Location = new Point(btnDelete.Location.X + btnDelete.Width + 6, btnStart.Location.Y);
            Invalidate(true);
        }
    }
}
