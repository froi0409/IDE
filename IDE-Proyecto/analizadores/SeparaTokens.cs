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

        public void SepararTokens(RichTextBox txtArea)
        {

            int cont = 0;

            String cadena = "";

            //for(int i = 0; i < txtArea.Text.Length; i++)
            //{

            //    if (Char.IsLetterOrDigit(txtArea.Text[i]) || txtArea.Text[i] == '.' || txtArea.Text[i] == '_')
            //    {
            //        cadena += txtArea.Text[i];
            //    }
            //    else if (cadena.Length > 0)
            //    {

            //    }
            //    else if (cadena)
            //    {

            //    }

            //}

            do
            {

                if(txtArea.Text[cont] == '"')
                {
                    int contAux = cont;
                    String cadenaAux = "";
                    bool comprobante = false;
                    do
                    {

                        cadenaAux += txtArea.Text[contAux];
                        contAux++;

                        if(txtArea.Text[contAux] == '"' || txtArea.Text[contAux] == '\n')
                        {

                            cadenaAux += txtArea.Text[contAux];
                            
                            if (automata.Comprobar(cadenaAux))
                            {
                                cont = contAux + 1;
                                tokens.Add(automata.TipoToken);
                            }

                            comprobante = true;
                            cadenaAux = "";

                        }

                    } while (!comprobante);
                }
                else if (txtArea.Text[cont] == '/' && txtArea.Text[cont+1] == '*')
                {

                    int contAux = cont;
                    String cadenaAux = "";
                    bool comprobante = false;

                    do
                    {

                        cadenaAux += txtArea.Text[contAux];
                        contAux++;

                        if((txtArea.Text[contAux] == '/' && txtArea.Text[contAux-1] == '*') || txtArea.Text[contAux] == '\n')
                        {

                            cadenaAux += txtArea.Text[contAux];

                            if (automata.Comprobar(cadenaAux))
                            {

                                cont = contAux + 1;
                                Console.WriteLine("Comment: " + cadenaAux);

                            }

                            comprobante = true;
                            cadenaAux = "";

                        }
                            
                    } while (!comprobante);

                }
                else
                {



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

    }
}
