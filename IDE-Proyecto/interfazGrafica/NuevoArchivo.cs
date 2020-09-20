using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IDE_Proyecto.interfazGrafica
{
    using archivos;
    public partial class NuevoArchivo : Form
    {

        private IDE ide;
        private FileProyecto proyecto;
        private String carpetaProyecto;

        public NuevoArchivo(IDE ide, FileProyecto proyecto, String carpetaProyecto)
        {
            InitializeComponent();
            this.ide = ide;
            this.proyecto = proyecto;
            this.carpetaProyecto = carpetaProyecto;
        }

        private void NuevoArchivo_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtNombre.TextLength > 1)
            {
                StreamWriter sw = new StreamWriter(carpetaProyecto + @"\" + txtNombre.Text + ".gt"); //Creamos el archivo nuevo
                sw.Close();
                proyecto.ListaCodigoFuente.Add(new FileCodigoFuente(txtNombre.Text + ".gt")); //Agregamos el archivo a la lista

                proyecto.ListaCodigoFuente[proyecto.ListaCodigoFuente.Count - 1].Contenido = "";

                ide.actualizacionDeRTB();
                ide.LlenadoDeArchivos(); //Actualizamos el listbox

                this.Visible = false; //cerramos el form de archivo nuevo
            }
            else
            {
                MessageBox.Show("El nombre del archivo es muy corto");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
