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
            if (cantLineasRT != cantLineas)
            {
                cantLineas = cantLineasRT;
                richTextBox1.Clear();
                for (int i = 1; i <= cantLineasRT; i++)
                {
                    richTextBox1.AppendText(i + "\n");
                }
            }

            //// create & set Point pt to (0,0)    
            //Point pt = new Point(0, 0);
            //// get First Index & First Line from richTextBox1    
            //int First_Index = richTextBox2.GetCharIndexFromPosition(pt);
            //int First_Line = richTextBox2.GetLineFromCharIndex(First_Index);
            //// set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            //pt.X = ClientRectangle.Width;
            //pt.Y = ClientRectangle.Height;
            //// get Last Index & Last Line from richTextBox1    
            //int Last_Index = richTextBox2.GetCharIndexFromPosition(pt);
            //int Last_Line = richTextBox2.GetLineFromCharIndex(Last_Index);
            
            //// set LineNumberTextBox text to null
            //richTextBox1.Text = "";
            //// now add each line number to LineNumberTextBox upto last line    
            //for (int i = First_Line; i <= Last_Line; i++)
            //{
            //    richTextBox1.Text += i + 1 + "\n";
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
    }
}
