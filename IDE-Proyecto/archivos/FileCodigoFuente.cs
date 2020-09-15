using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE_Proyecto.archivos
{

    class FileCodigoFuente : ManipulacionArchivo
    {

        private OpenFileDialog ofd = new OpenFileDialog();
        private FolderBrowserDialog fbd = new FolderBrowserDialog();

        public FileCodigoFuente()
        {
            
        }

        public override void Abrir(RichTextBox txtArea, ListBox lstArchivos)
        {
            
        }

        public override void Crear(RichTextBox txtArea, ListBox lstArchivos) 
        {
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Folder: " + fbd.SelectedPath);
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un archivo o de elegir un nombre");
                Crear(txtArea, lstArchivos);
            }
        }

        public override void Guardar(String ruta)
        {
            
        }
    }
}
