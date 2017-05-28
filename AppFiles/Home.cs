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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            weighted.Height = unweighted.Height= this.Height/4;
            unweighted.Location = new Point(unweighted.Location.X, this.Height-this.Height/4-70);
        }

        private void weighted_Click(object sender, EventArgs e)
        {
            //weighted.Enabled = false;
            WeightedGraph g = new WeightedGraph();
            g.Show();
        }

        private void unweighted_Click(object sender, EventArgs e)
        {
            //unweighted.Enabled = false;
            UnweightedGraph g = new UnweightedGraph();
            g.Show();
        }
    }
}
