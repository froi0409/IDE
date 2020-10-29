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
        private RichTextBox txtArea;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="nombre">Nombre del archivo .gt</param>
        public FileCodigoFuente(String nombre)
        {
            this.nombre = nombre;
            this.contenido = "";
        }

        public override void Abrir(String ruta)
        {
            StreamReader sr = new StreamReader(ruta);
            Contenido = sr.ReadToEnd();
            sr.Close();

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
            }

        }

        /// <summary>
        /// Método encargado de comprobar si el contenido de este objeto, en comparación al archivo original, ha cambiado
        /// Este método normalmente debe ejecutarse al cerrar el ide
        /// </summary>
        /// <param name="ruta"></param>
        public bool Comprobacion(String ruta)
        {

            try
            {

                StreamReader sr = new StreamReader(ruta);
                if (contenido.Equals(sr.ReadToEnd()))
                {
                    sr.Close();
                    return true;
                }
                else
                {
                    sr.Close();
                    return false;
                }
                
            }
            catch(IOException e)
            {
                MessageBox.Show("Ha ocurrido un problema a la hora de leer el archivo\n" +
                    "favor de verificar que el archivo no esté corrupto");
                return false;
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
