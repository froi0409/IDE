using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace IDE_Proyecto.archivos
{
    public class FileProyecto : ManipulacionArchivo
    {

        private List<FileCodigoFuente> codigoFuente;
        
        public FileProyecto()
        {
            codigoFuente = new List<FileCodigoFuente>();
        }

        public override void Abrir(RichTextBox txtArea, ListBox lstArchivos)
        {

        }

        public override void Crear(RichTextBox txtArea, ListBox lstArchivos)
        {

        }

        public override void Guardar(String ruta)
        {

        }

        public List<FileCodigoFuente> ListaCodigoFuente
        {
            get
            {
                return codigoFuente;
            }
        }
    }
}
