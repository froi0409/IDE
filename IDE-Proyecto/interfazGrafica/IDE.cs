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

    using archivos;
    using analizadores;

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

        //Variables que utilizará la clase
        private int cantLineas = 1, selectedFile = 0;
        private String nombre, tipoDeCreacion, carpetaArchivos;
        private FileProyecto proyecto;
        private List<FileProyecto> archivos = new List<FileProyecto>(); //* Lista pensada para tener los archivos sin las modificaciones que se realicen en el IDE */

        public IDE(FileProyecto proyecto, String nombre, String tipoDeCreacion, String carpetaArchivos)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.tipoDeCreacion = tipoDeCreacion;
            this.proyecto = proyecto;
            this.carpetaArchivos = carpetaArchivos;
            txtNumeracion.Text = "1";
            LlenadoDeArchivos();
        }

        /// <summary>
        /// Método que nos sirve para inicializar el IDE
        /// </summary>
        private void IDE_Load(object sender, EventArgs e)
        {
            txtArea.Text = proyecto.ListaCodigoFuente[0].Contenido;
            lstArchivos.SelectedIndex = 0;
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizacionDeRTB();
        }

        public void actualizacionDeRTB()
        {

            proyecto.ListaCodigoFuente[selectedFile].Contenido = txtArea.Text; //Le asignamos el texto correspondiente al espacio de texto de cada archivo
            selectedFile = lstArchivos.SelectedIndex;
            txtArea.Text = proyecto.ListaCodigoFuente[selectedFile].Contenido; //Le asignamos el texto del archivo seleccionado a txtArea

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            int index = txtArea.SelectionStart;
            int line = txtArea.GetLineFromCharIndex(index);

            int firstChar = txtArea.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;
            coordenadas();

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

            int strt = column - 1;
            if (column != 0)
            {
                while (txtArea.Lines[line][strt] != ' ' && strt > 1)
                {
                    strt--;
                }
            }
            Pintar(strt);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            actualizacionDeRTB();
            for(int i = 0; i < proyecto.ListaCodigoFuente.Count; i++)
            {
                lstArchivos.SelectedIndex = i;
                proyecto.ListaCodigoFuente[i].Guardar(carpetaArchivos + @"\" + lstArchivos.SelectedItem.ToString());
            }
        }

        public void LlenadoDeArchivos()
        {
            lstArchivos.Items.Clear();
            foreach (FileCodigoFuente element in proyecto.ListaCodigoFuente)
            {
                lstArchivos.Items.Add(element.Nombre);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            actualizacionDeRTB();
            proyecto.ListaCodigoFuente[selectedFile].Guardar(carpetaArchivos + @"\" + lstArchivos.SelectedItem.ToString());
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NuevoArchivo na = new NuevoArchivo(this, proyecto, carpetaArchivos);
            na.Visible = true;
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void txtNumeracion_TextChanged(object sender, EventArgs e)
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

        private void txtArea_Click(object sender, EventArgs e)
        {
            coordenadas();
        }

        private void txtArea_KeyUp(object sender, KeyEventArgs e)
        {
            int index = txtArea.SelectionStart;
            int line = txtArea.GetLineFromCharIndex(index);

            int firstChar = txtArea.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;

            coordenadas();

            //if (column != 0 && txtArea.Lines[line][column - 1] == ' ')
            //{
            //    int strt = column - 2;

            //    while (txtArea.Lines[line][strt] != 0 && strt > 0)
            //    {
            //        if (txtArea.Lines[line][strt - 1] == ' ')
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            strt--;
            //        }
            //    }
            //    Pintar(strt);
            //}

            //int strt = column - 1;
            //if(column != 0)
            //{
            //    while (txtArea.Lines[line][strt] != ' ' && strt > 1)
            //    {
            //        strt--;
            //    }
            //}
            //Pintar(strt);

        }


        /// <summary>
        /// Método que nos sirve para definir el comportamiento del formulario
        /// después de ser cerrado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IDE_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); //Nos permite salir de la aplicación
        }

        private void txtArea_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        /// <summary>
        /// Método que nos sirve para definir el comportamiento del formulario
        /// antes de ser cerrado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IDE_FormClosing(object sender, FormClosingEventArgs e)
        {
            actualizacionDeRTB();
            foreach(FileCodigoFuente element in proyecto.ListaCodigoFuente)
            {
                if(!element.Comprobacion(carpetaArchivos + @"\" + element.Nombre))
                {
                    DialogResult dialog = MessageBox.Show("Se han detectado cambios sin guardar, ¿Desea guardar cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        button6_Click(sender, e);

                    }
                    break;
                }
            }
        }

        private void coordenadas()
        {
            //Las siguientes lineas nos sirven para definir la posición del cursor
            int index = txtArea.SelectionStart;
            int line = txtArea.GetLineFromCharIndex(index);
            

            int firstChar = txtArea.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;

            lblPosicion.Text = "Posición: (" + (line+1) + "," + (column+1) + ")";
        }

        private void Pintar(int strt)
        {
            int index = txtArea.SelectionStart;
            int line = txtArea.GetLineFromCharIndex(index);

            int firstChar = txtArea.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;

            //if (strt > 0)
            //{
            try
            {
                Automata au = new Automata(txtArea.Lines[line].Substring(strt + 1, (column) - strt - 1));

                int apoyo = 0;
                for (int i = 0; i < line; i++)
                {
                    apoyo += txtArea.Lines[i].Length;
                    apoyo++;
                }
                if (au.Aceptacion)
                {
                    if (txtArea.Lines.Length == 1)
                        txtArea.Select(strt, (column) - strt);
                    else
                    {
                        txtArea.Select(apoyo + strt, (column) - strt);
                        Console.WriteLine(apoyo + "\nsi entró");
                    }

                    txtArea.SelectionColor = Color.FromName(au.Color);
                    txtArea.SelectionStart = index;
                    txtArea.SelectionLength = 0;
                    txtArea.SelectionColor = Color.Black;
                }
            } catch (Exception e)
            {

            }
            //}
        }
    }
}