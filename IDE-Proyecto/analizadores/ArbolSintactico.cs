using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE_Proyecto.analizadores
{
    class ArbolSintactico
    {

        private List<String> entrada = new List<String>();
        private List<Token> informacion = new List<Token>();

        public ArbolSintactico(List<String> entrada, List<Token> informacion)
        {

            foreach (String element in entrada)
            {
                this.entrada.Add(element);
            }
            foreach (Token element in informacion)
            {
                this.informacion.Add(element);
            }
        }

        public String dotCode()
        {
            String codigo = "graph arbolSintactico { graph [ordering=\"out\"];";

            bool comprobante = true;
            List<String> pila = new List<String>();
            List<Nodo> nodosActivos = new List<Nodo>();
            int contNodo = 0;
            TablaAnalisisSintactico tas = new TablaAnalisisSintactico();
            IdentificadoresTabla find = new IdentificadoresTabla();

            pila.Add("$");
            pila.Add("Codigo");
            nodosActivos.Add(new Nodo("Codigo", 0));
            codigo += " Nodo0[shape=circle,label=\"Codigo\"]; ";

            do
            {
                Console.WriteLine("------------------------------------------------------");
                foreach (String element in pila)
                {
                    Console.Write("  " + element);
                }
                Console.WriteLine();
                foreach (String element in entrada)
                {
                    Console.Write("  " + element);
                }

                //si los ultimos elementos de ambas listas son iguales, se eliminan
                if (pila[pila.Count - 1].Equals(entrada[entrada.Count - 1]))
                {

                    pila.RemoveAt(pila.Count - 1);
                    entrada.RemoveAt(entrada.Count - 1);
                    if(nodosActivos.Count > 0)
                        nodosActivos.RemoveAt(nodosActivos.Count - 1);

                }
                else if (pila[pila.Count - 1].Equals("e"))
                {
                    pila.RemoveAt(pila.Count - 1);
                    nodosActivos.RemoveAt(nodosActivos.Count - 1);
                }
                else //Se busca en la tabla los reemplazos para el último en la pila
                {
                    String noTerminal = pila[pila.Count - 1];
                    pila.RemoveAt(pila.Count - 1);
                    int cont = 0, contNodoAux = nodosActivos[nodosActivos.Count - 1].Numero;


                    int fila = Array.IndexOf(find.Fila, noTerminal);
                    int columna = Array.IndexOf(find.Columna, entrada[entrada.Count - 1]);
                    try
                    {
                        foreach (String element in tas.Tabla[fila, columna])
                        {
                            contNodo++;

                            pila.Add(element);
                            nodosActivos.Add(new Nodo(element, contNodo));
                            codigo += " \nNodo" + contNodo + "[shape=circle,label=\"" + element + "\"]; \nNodo" + contNodoAux + " -- Nodo" + contNodo + "; ";
                            cont++;
                        }

                        nodosActivos.RemoveAt(contNodoAux);

                    }
                    catch (Exception ex)
                    {
                        
                    }

                }

                Console.WriteLine("\n\n");

            } while (pila.Count != 0 && comprobante);

            codigo += "\n}";

            return codigo;

        }

    }

    class Nodo {

        private String nombre;
        private int posicion;

        public Nodo(String nombre, int posicion) {
            this.nombre = nombre;
            this.posicion = posicion;
        }

        public String Nombre {
            get
            {
                return nombre;
            }
        }

        public int Numero
        {
            set
            {
                posicion = value;
            }
            get
            {
                return posicion;
            }
        }

        public override string ToString()
        {
            return nombre;
        }

    }

}
