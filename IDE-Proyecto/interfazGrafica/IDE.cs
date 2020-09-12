using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE_Proyecto.interfazGrafica
{
    public partial class IDE : Form
    {
        public IDE()
        {
            InitializeComponent();
        }

        private void IDE_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == 1)
            {
                MessageBox.Show("JAJAJAJA SIUUU");
            }
        }
    }
}
