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
    public partial class InputWeight : Form
    {
        public int weight;
        public InputWeight()
        {
            InitializeComponent();
            weight = 0;
        }

        private void tbxInput_Validating(object sender, CancelEventArgs e)
        {
            string temp = tbxInput.Text.Trim();
            bool valid = Int32.TryParse(temp,out weight);
            if(temp.Length==0 || temp.Length > 3 || !valid || weight<=0)
            {
                errorProvider1.SetError(tbxInput, "Input a nonnegative number who has between 1 and 3 digits");
                weight = 0;
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbxInput, null);
                e.Cancel = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
