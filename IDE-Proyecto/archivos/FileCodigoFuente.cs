using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE_Proyecto.archivos
{

    public class FileCodigoFuente : ManipulacionArchivo
    {

        private RichTextBox contenido;
        private String nombre;

        public FileCodigoFuente(String nombre)
        {
            contenido = new RichTextBox();
            this.nombre = nombre;
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

        public RichTextBox Contenido
        {
            get
            {
                return contenido;
            }
        }

        public String Nombre
        {
            get
            {
                return nombre;
            }
        }
    }
}
