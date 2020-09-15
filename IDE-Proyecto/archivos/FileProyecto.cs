using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace IDE_Proyecto.archivos
{
    public class FileProyecto : ManipulacionArchivo
    {

        private ArrayList codigoFuente;

        public FileProyecto()
        {
            codigoFuente = new ArrayList();
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

        public ArrayList ListaCodigoFuente
        {
            get
            {
                return codigoFuente;
            }
        }
    }
}
