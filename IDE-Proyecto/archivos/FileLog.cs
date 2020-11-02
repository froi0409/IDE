using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IDE_Proyecto.archivos
{
    class FileLog
    {

        /// <summary>
        /// Metordo que nos permite crear un archivo .gtE dentro de la carpeta del proyecto
        /// </summary>
        /// <param name="ruta">Ubicación de la carpeta del proyecto</param>
        /// <param name="nombre">Nombre del archivo .gtE</param>
        /// <param name="txtLog">Instancia el área Log del IDE</param>
        public void Crear(String ruta, String nombre, RichTextBox txtLog)
        {
            StreamWriter sw = new StreamWriter(ruta + @"\" + nombre + "E");
            sw.WriteLine("Reporte de Errores - " + nombre + "E");
            sw.Write(txtLog.Text);
            sw.Close();
            MessageBox.Show("Archivo .gtE Exportado con éxito");

        }

    }
}
