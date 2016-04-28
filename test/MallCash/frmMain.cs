using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MallCash
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            comboBox1.Items.Insert(0,"normal");
            comboBox1.Items.Insert(1,"discount");
            comboBox1.Items.Insert(2,"return");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cash c = CashFactory.CreatCash(comboBox1.SelectedIndex);
            label1.Text = c.finalCash(Convert.ToDouble(textBox1.Text)).ToString();
        }
    }
}
