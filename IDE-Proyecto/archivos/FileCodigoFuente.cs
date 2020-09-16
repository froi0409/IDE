using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IDE_Proyecto.archivos
{

    public class FileCodigoFuente : ManipulacionArchivo
    {

        private String contenido;
        private String nombre;

        public FileCodigoFuente(String nombre)
        {
            this.nombre = nombre;
        }

        public override void Abrir(RichTextBox txtArea, ListBox lstArchivos)
        {
            
        }

        public override void Crear(RichTextBox txtArea, ListBox lstArchivos) 
        {
            
        }

        /// <summary>
        /// Método que nos sirve para sobreescribir un archivo
        /// </summary>
        /// <param name="ruta">Ruta COMPLETA del archivo a sobreescribir</param>
        public override void Guardar(String ruta)
        {

            using (StreamWriter writer = new StreamWriter(ruta))
            {
                writer.Write(contenido); //Esta linea escribe en el archivo cada linea de texto
                writer.Close();
                MessageBox.Show("Cambios realizazos\n\n" + contenido);
            }

        }

        public String Contenido
        {
            get
            {
                return contenido;
            }
            set
            {
                contenido = value;
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
