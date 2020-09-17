using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE_Proyecto.archivos
{
    public abstract class ManipulacionArchivo
    {

        public abstract void Abrir(String ruta);
        public abstract void Crear(RichTextBox txtArea, ListBox lstArchivos);
        public abstract void Guardar(String ruta);


    }
}
