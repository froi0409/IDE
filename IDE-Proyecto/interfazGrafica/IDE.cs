using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IDE_Proyecto.interfazGrafica
{

    //Todos los enum sirven para la sincronización entre los richTextBox
    public enum ScrollBarType : uint
    {
        SbHorz = 0,
        SbVert = 1,
        SbCtl = 2,
        SbBoth = 3
    }

    public enum Message : uint
    {
        WM_VSCROLL = 0x0115
    }

    public enum ScrollBarCommands : uint
    {
        SB_THUMBPOSITION = 4
    }

    public partial class IDE : Form
    {

        //Los DllImport también sirven para la sincronización entre los dos richTextBox
        [DllImport("User32.dll")]
        public extern static int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);




        private int cantLineas = 1;
        public IDE()
        {
            InitializeComponent();
            txtNumeracion.Text = "1";
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

            //Condicion que nos sirve para verificar si hay alguna linea adicional
            int cantLineasRT = txtArea.Lines.Length;
            if (cantLineasRT != cantLineas)
            {
                cantLineas = cantLineasRT;
                txtNumeracion.Clear();
                for (int i = 1; i <= cantLineasRT; i++)
                {
                    txtNumeracion.AppendText(i + "\n");
                }
                txtArea_VScroll(sender, e);
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Sirve para desplazar el área de texto al mismo tiempo que a numeración
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtArea_VScroll(object sender, EventArgs e)
        {
            int nPos = GetScrollPos(txtArea.Handle, (int)ScrollBarType.SbVert);
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(txtNumeracion.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
        }
    }
}
