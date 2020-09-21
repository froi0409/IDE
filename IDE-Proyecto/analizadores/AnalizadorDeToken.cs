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
        private List<char> Separacion = new List<char>();
        private int index, line, column, firstChar, startcomment = 0, lengthcomment = 0, commentline = 0;
        private Automata automata = new Automata();
        private bool comment = false;

        public AnalizadorDeToken(RichTextBox txtArea)
        {
            this.txtArea = txtArea;
            Inicialización();
        }

        private void Inicialización()
        {
            Separacion.Add(' ');
            Separacion.Add('-');
            Separacion.Add('+');
            Separacion.Add('*');
            Separacion.Add('/');
            Separacion.Add('>');
            Separacion.Add('<');
            Separacion.Add('=');
            Separacion.Add('!');
            Separacion.Add('|');
            Separacion.Add('&');
            Separacion.Add('(');
            Separacion.Add(')');
            Separacion.Add(';');
        }

        public void AnalizarToken()
        {

            ActualizarDatos();

            if (index == txtArea.TextLength)
            {
                try
                {
                    int strt = column - 1;
                    if (automata.Comprobar(txtArea.Lines[line].Substring(strt, 1)))
                    {
                        Pintar(strt, 1);
                    }
                    char[] lastLetter = txtArea.Lines[line].Substring(strt, 1).ToCharArray();

                    //Si obtenemos letras, las enviamos al autómata
                    

                    if (Char.IsLetter(txtArea.Lines[line][strt]))
                    {
                        int strt2 = strt;
                        int length;

                        while (strt2 > 0 && (Char.IsLetter(txtArea.Lines[line][strt2]) || txtArea.Lines[line][strt2] == '_'))
                        {
                            if (!Char.IsLetter(txtArea.Lines[line][strt2 - 1]) && txtArea.Lines[line][strt2 - 1] != '_')
                            {
                                break;
                            }
                            else
                                strt2--;

                        }
                        length = column - strt2;
                        if (automata.Comprobar(txtArea.Lines[line].Substring(strt2, length)));
                            Pintar(strt2, length);
                    }
                    else if(Char.IsNumber(txtArea.Lines[line][strt]) || txtArea.Lines[line][strt] == '.')
                    {
                        int strt2 = strt;
                        int length;

                        while (strt2 > 0 && (Char.IsNumber(txtArea.Lines[line][strt2]) || txtArea.Lines[line][strt2] == '.'))
                        {
                            if (!Char.IsNumber(txtArea.Lines[line][strt2 - 1]) && txtArea.Lines[line][strt2 - 1] != '.')
                            {
                                break;
                            }
                            else
                                strt2--;

                        }
                        length = column - strt2;
                        if (automata.Comprobar(txtArea.Lines[line].Substring(strt2, length))) ;
                        Pintar(strt2, length);
                    }

 
                    //Obtenemos comentarios
                    try
                    {

                        //if (comment == true && txtArea.Lines[line][strt] == '/' && txtArea.Lines[line][strt - 1] == '*')
                        //{
                        //    lengthcomment += 2;
                            
                        //    Console.WriteLine("Cadena de comentarrio: " + txtArea.Text.Substring(startcomment, lengthcomment));

                            

                        //    if (automata.Comprobar(txtArea.Text.Substring(startcomment, lengthcomment)))
                        //    {
                        //        Pintar(startcomment, lengthcomment);
                        //    }

                        //    comment = false;
                        //    lengthcomment = 0;
                        //}

                        //if (txtArea.Lines[line][strt] == '*' && txtArea.Lines[line][strt - 1] == '/')
                        //{
                        //    startcomment = column - 2;
                        //    lengthcomment = 0;
                        //    comment = true;
                        //}

                        //if (comment == true)
                        //{
                        //    lengthcomment++;
                        //}

                    }
                    catch { }

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
