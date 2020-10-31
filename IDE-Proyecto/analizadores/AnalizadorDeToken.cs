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
        private List<char> Dobles = new List<char>();
        private int index, line, column, firstChar;
        private Automata automata = new Automata();
        private List<Token> tokens = new List<Token>();


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="txtArea">Instancia del área de texto del IDE</param>
        public AnalizadorDeToken(RichTextBox txtArea)
        {
            this.txtArea = txtArea;
            Inicialización();
        }

        /// <summary>
        /// Inicializa aquellos tokens, que son el fin de cadenas de dos caracteres
        /// </summary>
        private void Inicialización()
        {
            Dobles.Add('|');
            Dobles.Add('&');
            Dobles.Add('=');
        }

        /// <summary>
        /// Este método analiza los diferentes tipos de tokens que el usuario puede ingresar
        /// desde tokens de un caracter, hasta tokens representados por cadenas de caracteres
        /// </summary>
        public void AnalizarToken()
        {

            ActualizarDatos();

            try
            {
                //Enviamos el caracter recién ingresado al autómata para determinar si el mismo es un token válido
                int strt = column - 1;
                if (automata.Comprobar(txtArea.Lines[line].Substring(strt, 1)))
                {
                    Pintar(strt, 1);
                    tokens.Add(new Token(automata.TipoToken, strt, column));
                }

                char[] lastLetter = txtArea.Lines[line].Substring(strt, 1).ToCharArray();


                //A continuación enviaremos los tokens que forman parte de cadenas de caracteres
                //Si obtenemos letras, las enviamos al autómata
                if (Char.IsLetter(txtArea.Lines[line][strt]))
                {
                    int strt2 = strt;
                    int length;

                    //Envío de palabras al autómata, strt2 es el inicio de la cadena
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
                    if (automata.Comprobar(txtArea.Lines[line].Substring(strt2, length)))
                        Pintar(strt2, length);
                }
                else if (Char.IsNumber(txtArea.Lines[line][strt]) || txtArea.Lines[line][strt] == '.')
                {
                    int strt2 = strt;
                    int length;

                    //Envío de números (enteros y decimales) al autómata, strt2 es el inicio de la cadena
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
                    automata.Comprobar(txtArea.Lines[line].Substring(strt2, length));
                    Pintar(strt2, length);
                }
                else if (strt > 0 && Dobles.Contains(txtArea.Lines[line][strt]))
                {
                    //Envío de cadenas de dos caracteres (ej: ==, <=, etc) al autómata, strt2 es el inicio de la cadena
                    Console.WriteLine("Cadena: " + txtArea.Lines[line].Substring(strt - 1, 2));
                    if (automata.Comprobar(txtArea.Lines[line].Substring(strt - 1, 2)))
                        Pintar(strt - 1, 2);
                }
                else if (txtArea.Lines[line][strt] == '+')
                {
                    int strt2 = strt;
                    int length;

                    //Envío de cadenas de signo + al autómata, strt2 es el inicio de la cadena
                    while (strt2 > 0 && txtArea.Lines[line][strt2] == '+')
                    {
                        if (txtArea.Lines[line][strt2 - 1] != '+')
                        {
                            break;
                        }
                        else
                            strt2--;
                    }
                    length = column - strt2;
                    automata.Comprobar(txtArea.Lines[line].Substring(strt2, length));
                    Pintar(strt2, length);
                }
                else if (txtArea.Lines[line][strt] == '-')
                {
                    int strt2 = strt;
                    int length;

                    //Envío de cadenas de signo - al autómata, strt2 es el inicio de la cadena
                    while (strt2 > 0 && txtArea.Lines[line][strt2] == '-')
                    {
                        if (txtArea.Lines[line][strt2 - 1] != '-')
                        {
                            break;
                        }
                        else
                            strt2--;
                    }
                    length = column - strt2;
                    automata.Comprobar(txtArea.Lines[line].Substring(strt2, length));
                    Pintar(strt2, length);
                }
                else if (txtArea.Lines[line][strt] == '"')
                {
                    int strt2 = strt;
                    int length;

                    //Envío de cadenas de caracteres - al autómata, strt2 es el inicio de la cadena
                    do
                    {
                        strt2--;
                    } while (strt2 > 0 && txtArea.Lines[line][strt2] != '"');
                    length = column - strt2;
                    if (automata.Comprobar(txtArea.Lines[line].Substring(strt2, length)))
                        Pintar(strt2, length);
                }
                else if (txtArea.Lines[line][strt] == '/' && txtArea.Lines[line][strt - 1] == '*')
                {
                    int strt2 = strt;
                    int length;

                    //Envío de cadenas de caracteres - al autómata, strt2 es el inicio de la cadena
                    do
                    {
                        do
                        {
                            strt2--;
                        } while (strt2 > 0 && txtArea.Lines[line][strt2] != '/');
                    } while (txtArea.Lines[line][strt2 + 1] != '*');
                    length = column - strt2;
                    automata.Comprobar(txtArea.Lines[line].Substring(strt2, length));
                    Pintar(strt2, length);
                }

            }
            catch (Exception ex)
            { }

        }

        /// <summary>
        /// Actualiza el número de fila y columna en la que se encuentra el cursor, dentro del área de texto
        /// </summary>
        private void ActualizarDatos()
        {
            index = txtArea.SelectionStart;
            line = txtArea.GetLineFromCharIndex(index);

            firstChar = txtArea.GetFirstCharIndexFromLine(line);
            column = index - firstChar;
        }

        /// <summary>
        /// Pinta la cadena de caracteres, según las condiciones establecidas por el autómata
        /// </summary>
        /// <param name="strt">Hace referencia al inicio de la cadena de caracteres a pintar</param>
        /// <param name="length">Hace referencia a la longitud de la cadena de caracteres a pintar</param>
        private void Pintar(int strt, int length)
        {
            int apoyo = 0;

            if (txtArea.Lines.Length == 1)
                txtArea.Select(strt, length);
            else
            {
                for (int i = 0; i < line; i++)
                {
                    apoyo += txtArea.Lines[i].Length;
                    apoyo++;
                }
                txtArea.Select(apoyo + strt, length);
            }

            txtArea.SelectionColor = Color.FromName(automata.Color);
            txtArea.SelectionStart = index;
            txtArea.SelectionLength = 0;
            txtArea.SelectionColor = Color.Black;

        } 

        public List<Token> ListaTokens
        {
            get
            {
                return tokens;
            }
        }

    }
}
