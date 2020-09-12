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
        private int cantLineas = 1;
        public IDE()
        {
            InitializeComponent();
            richTextBox1.Text = "1";
        }

        private void IDE_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            int cantLineasRT = richTextBox2.Lines.Length;
            if(cantLineasRT != cantLineas)
            {
                cantLineas = cantLineasRT;
                richTextBox1.Clear();
                for(int i = 1; i <= cantLineasRT; i++)
                {
                    richTextBox1.AppendText(i + "\n");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(richTextBox2.SelectionStart.ToString());
        }
    }
}
