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
        
        /// <summary>
        /// Constructor de la clase.
        /// Todo objeto de tipo FileProyecto posee un List<FileCodigoFuente> 
        /// </summary>
        public FileProyecto()
        {
            codigoFuente = new List<FileCodigoFuente>();
        }

        public override void Abrir(String ruta)
        {
            
        }

        public override void Crear(RichTextBox txtArea, ListBox lstArchivos)
        {

        }

        public override void Guardar(String ruta)
        {

        }

        /// <summary>
        /// Obtenemos el List de Codigo Fuente que el proyecto tendrá 
        /// </summary>
        public List<FileCodigoFuente> ListaCodigoFuente
        {
            get
            {
                return codigoFuente;
            }
        }
    }
}
