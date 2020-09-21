using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE_Proyecto.analizadores
{
    class AnalizadorLog
    {

        public AnalizadorLog()
        {

        }

        public void Analizar(RichTextBox txtArea, TextBox txtLog, int index)
        {

            int index2, line;

            txtArea.SelectionStart = 0;
            txtArea.SelectionLength = 0;
            String error = "";
            Console.WriteLine(txtArea.TextLength + " Longitud");
            for (int i = 0; i < txtArea.TextLength; i++)
            {
                index2 = txtArea.SelectionStart;
                line = txtArea.GetLineFromCharIndex(index2);
                txtArea.Select(i, 1);
                
                if (txtArea.SelectionColor == Color.Black) //Comprobamos si la palabra está pintada de color negro
                {
                    error += txtArea.Text[i];
                }
                if (txtArea.SelectionColor != Color.Black || error.Length == txtArea.TextLength)
                {
                    if (error.Length > 1)
                    {
                        txtLog.Text += (Environment.NewLine + "Error en linea " + (line+1) + " - Descripción: " + error);
                        error = "";
                    }
                }
            }
            index2 = txtArea.SelectionStart;
            line = txtArea.GetLineFromCharIndex(index2);
            if (error.Length > 1) //Añadimos el error, en dado caso este pertenezca a la última cadena del área de texto
            {
                txtLog.Text += (Environment.NewLine + "Error en linea " + (line+1) + " - Descripción: " + error);
            }
            txtArea.SelectionStart = index;
            txtArea.SelectionLength = 0;
        }

    }
}
