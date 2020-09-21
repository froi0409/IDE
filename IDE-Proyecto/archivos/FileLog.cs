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

        public void Crear(String ruta, String nombre, TextBox txtLog)
        {
            StreamWriter sw = new StreamWriter(ruta + @"\" + nombre + "E");
            sw.WriteLine("Reporte de Errores - " + nombre + "E");
            sw.Write(txtLog.Text);
            sw.Close();
            MessageBox.Show("Archivo .gtE Exportado con éxito");

        }

    }
}
