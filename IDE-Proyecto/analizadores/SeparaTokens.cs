using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE_Proyecto.analizadores
{
    class SeparaTokens
    {

        private Automata automata = new Automata();
        private List<String> tokens = new List<String>();
        private List<char> operadores;

        public SeparaTokens ()
        {
            inicializarOperadores();
        }

        private void inicializarOperadores()
        {
            operadores = new List<char>();
            operadores.Add('+');
            operadores.Add('-');
            operadores.Add('*');
            operadores.Add('/');
            operadores.Add('<');
            operadores.Add('>');
            operadores.Add('=');
            operadores.Add('!');
            operadores.Add('|');
            operadores.Add('&');
        }

        public void SepararTokens(RichTextBox txtArea, RichTextBox txtLog)
        {
            int cont = 0;
            String cadena = "";

            do
            {

                int index = cont;
                int line = txtArea.GetLineFromCharIndex(index);

                int firstChar = txtArea.GetFirstCharIndexFromLine(line);
                int column = index - firstChar;

                if (txtArea.Text[cont] == '"')
                {
                    int contAux = cont;
                    String cadenaAux = "";
                    bool comprobante = false;
                    do
                    {

                        cadenaAux += txtArea.Text[contAux];
                        contAux++;

                        if (txtArea.Text[contAux] == '"' || txtArea.Text[contAux] == '\n' || contAux == txtArea.Text.Length)
                        {

                            cadenaAux += txtArea.Text[contAux];

                            if (automata.Comprobar(cadenaAux))
                            {
                                cont = contAux;
                                tokens.Add(automata.TipoToken);
                            }

                            comprobante = true;
                            cadenaAux = "";

                        }

                    } while (!comprobante);
                }
                else if (txtArea.Text[cont] == '/' && txtArea.Text[cont + 1] == '*')
                {

                    int contAux = cont;
                    String cadenaAux = "";
                    bool comprobante = false;

                    do
                    {

                        cadenaAux += txtArea.Text[contAux];
                        contAux++;

                        if ((txtArea.Text[contAux] == '/' && txtArea.Text[contAux - 1] == '*') || txtArea.Text[contAux] == '\n' || contAux == txtArea.Text.Length)
                        {

                            cadenaAux += txtArea.Text[contAux];

                            if (automata.Comprobar(cadenaAux))
                            {
                                cont = contAux;
                            }

                            comprobante = true;
                            cadenaAux = "";

                        }

                    } while (!comprobante);

                }
                else if (Char.IsLetterOrDigit(txtArea.Text[cont]) || txtArea.Text[cont] == '.' || txtArea.Text[cont] == '_')
                {
                    int contAux = cont;
                    String cadenaAux = "";
                    bool comprobante = false;
                    do
                    {

                        cadenaAux += txtArea.Text[contAux];
                        contAux++;

                        if (!Char.IsLetterOrDigit(txtArea.Text[contAux]) && txtArea.Text[contAux] != '.' && txtArea.Text[contAux] != '_')
                        {
                            comprobante = true;
                            cont = contAux - 1;
                            if (automata.Comprobar(cadenaAux))
                            {
                                tokens.Add(automata.TipoToken);
                            }
                            else
                            {
                                txtLog.AppendText(Environment.NewLine + "Error Léxico en: (" + (line + 1) + "," + (column + 1) + ")");
                            }
                        }

                    } while (!comprobante);

                }
                else if (operadores.Contains(txtArea.Text[cont]))
                {
                    int contAux = cont;
                    String cadenaAux = "";
                    bool comprobante = false;

                    do
                    {
                        cadenaAux += txtArea.Text[contAux];
                        contAux++;
                        if (!operadores.Contains(txtArea.Text[contAux]) || contAux == txtArea.Text.Length)
                        {
                            comprobante = true;
                            cont = contAux - 1;

                            if (automata.Comprobar(cadenaAux))
                            {
                                tokens.Add(automata.TipoToken);
                            }
                            else
                            {
                                txtLog.AppendText(Environment.NewLine + "Error Léxico en: (" + (line + 1) + "," + (column + 1) + ")");
                            }

                        }
                    } while (!comprobante);

                }
                else if (automata.Comprobar(txtArea.Text[cont].ToString()))
                {
                    tokens.Add(automata.TipoToken);
                }

                cont++;
            } while (cont < txtArea.Text.Length);

        }

        public List<String> ListaTokens
        {
            get
            {
                return tokens;
            }
        }
        private List<String> coord = new List<String>();
        private void errorLexico(RichTextBox txtArea, TextBox txtLog)
        {

            List<String> coord = new List<String>();

            int index = txtArea.SelectionStart;
            int line = txtArea.GetLineFromCharIndex(index);

            int firstChar = txtArea.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;

            if (!coord.Contains((line+1) + "," + (column+1))) {
                txtLog.Text += Environment.NewLine + "Error Lexico en (" + (line + 1) + "," + (column + 1) + ")";
                coord.Add((line + 1) + "," + (column + 1));
            }


        }

    }
    
}
