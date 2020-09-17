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
    public partial class AperturaArchivo : Form
    {

        private PantallaInicial pantallaInicial;

        public AperturaArchivo(PantallaInicial pantallaInicial)
        {
            InitializeComponent();
            this.pantallaInicial = pantallaInicial;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if(result == DialogResult.OK)
            {
                txtRuta.Text = fbd.SelectedPath;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtRuta.TextLength > 1 && Directory.Exists(txtRuta.Text))
            {
                String carpeta = txtRuta.Text;
                String nombreProyecto = Path.GetFileName(Path.GetDirectoryName(carpeta));
                FileProyecto proyecto = new FileProyecto();
                DirectoryInfo d = new DirectoryInfo(carpeta);//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.gt"); //Getting Text files

                int cont = 0;

                foreach (FileInfo file in Files)
                {
                    proyecto.ListaCodigoFuente.Add(new FileCodigoFuente(file.Name));
                    proyecto.ListaCodigoFuente[cont].Abrir(carpeta + @"\" + file.Name);
                    cont++;
                }

                IDE ide = new IDE(proyecto, nombreProyecto, "AperturaProyecto", carpeta);
                ide.Visible = true;
                this.Visible = false;

            }
            else
            {
                MessageBox.Show("Favor Ingresar la ruta del proyecto", "Ruta inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
