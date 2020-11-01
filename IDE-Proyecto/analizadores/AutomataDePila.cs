using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE_Proyecto.analizadores
{
    class AutomataDePila
    {

        private List<String> entrada;

        public AutomataDePila(List<String> entrada)
        {
            this.entrada = entrada;
        }

        public bool verificarSintaxis()
        {
            bool comprobante = true;
            List<String> pila = new List<String>();
            TablaAnalisisSintactico tas = new TablaAnalisisSintactico();
            IdentificadoresTabla find = new IdentificadoresTabla();

            pila.Add("$");
            pila.Add("Codigo");

            do
            {
                Console.WriteLine("------------------------------------------------------");
                foreach(String element in pila)
                {
                    Console.Write("  " + element);
                }
                Console.WriteLine();
                foreach(String element in entrada)
                {
                    Console.Write("  " + element);
                }

                //si los ultimos elementos de ambas listas son iguales, se eliminan
                if (pila[pila.Count-1].Equals(entrada[entrada.Count - 1]))
                {

                    pila.RemoveAt(pila.Count - 1);
                    entrada.RemoveAt(entrada.Count - 1);

                }
                else if (pila[pila.Count - 1].Equals("e"))
                {
                    pila.RemoveAt(pila.Count - 1);
                }
                else //Se busca en la tabla los reemplazos para el último en la pila
                {
                    String noTerminal = pila[pila.Count - 1];
                    pila.RemoveAt(pila.Count - 1);
                    int cont = 0;

                    int fila = Array.IndexOf(find.Fila, noTerminal);
                    int columna = Array.IndexOf(find.Columna, entrada[entrada.Count - 1]);
                    //Console.WriteLine("\n\nFila: " + fila + "   Columna: " + columna);
                    try
                    {
                        foreach (String element in tas.Tabla[fila, columna])
                        {
                            pila.Add(element);
                            cont++;
                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        comprobante = false;
                    }

                    if(cont == 0)
                    {
                        comprobante = false;
                    }
                }

                Console.WriteLine("\n\n");

            } while (pila.Count != 0 && comprobante);

            //Si la pila o la entrada no están vacías quiere decir que el análisis sintáctico no fue satisfactorio
            if(pila.Count != 0 || entrada.Count != 0)
            {
                comprobante = false;
                Console.WriteLine("Hay errores sintácticos en el análisis");
            }

            return comprobante;
        }

    }
}
