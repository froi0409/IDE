using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE_Proyecto.analizadores
{
    class AnalizadorDeToken
    {

        private RichTextBox txtArea;
        private int index, line, column, firstChar;
        Automata automata = new Automata();

        public AnalizadorDeToken(RichTextBox txtArea)
        {
            this.txtArea = txtArea;
        }

        public void AnalizarToken()
        {

            ActualizarDatos();

            if (index == txtArea.TextLength)
            {
                //try
                //{
                //    int strt = column - 1;
                //    int length;
                //    while (strt > 0 && txtArea.Lines[line][strt] != ' ')
                //    {
                //        if (txtArea.Lines[line][strt - 1] == ' ')
                //        {
                //            break;
                //        }
                //        else
                //            strt--;

                //    }
                //    length = column - strt;
                //    Pintar(strt, length);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex);
                //}

                //Automata au = new Automata(txtArea.Lines[line].Substring(strt, length));
                try
                {
                    int strt = column - 1;
                    automata.Comprobar(txtArea.Lines[line].Substring(strt, 1));
                    Console.WriteLine("token: " + txtArea.Lines[line].Substring(strt, 1));
                    if (automata.Aceptacion)
                    {
                        Pintar(strt, 1);
                    }
                }
                catch (Exception ex)
                {}
            }
        }

        private void ActualizarDatos()
        {
            index = txtArea.SelectionStart;
            line = txtArea.GetLineFromCharIndex(index);

            firstChar = txtArea.GetFirstCharIndexFromLine(line);
            column = index - firstChar;
        }

        private void Pintar(int strt, int length)
        {
            
            int apoyo = 0;
            for (int i = 0; i < line; i++)
            {
                apoyo += txtArea.Lines[i].Length;
                apoyo++;
            }

            if (txtArea.Lines.Length == 1)
                txtArea.Select(strt, length);
            else
            {
                txtArea.Select(apoyo + strt, length);
            }

            txtArea.SelectionColor = Color.FromName(automata.Color);
            txtArea.SelectionStart = index;
            txtArea.SelectionLength = 0;
            txtArea.SelectionColor = Color.Black;
 
        }

    }
}
