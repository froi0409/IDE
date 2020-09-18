using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE_Proyecto.analizadores
{
    class Automata
    {
        private int cont, longitud;
        private String cadenaIngresada;
        private bool aceptacion;
        private char[] cadena;

        public Automata(String cadenaIngresada)
        {
            cont = 0;
            aceptacion = false;
            this.cadenaIngresada = cadenaIngresada;
            longitud = cadenaIngresada.Length;
            cadena = cadenaIngresada.ToCharArray();

            Console.WriteLine("Para la cadena: " + cadenaIngresada + "\n\n");

            Q0();

        }

        public void Q0()
        {
            Console.WriteLine("Q0");
            aceptacion = false;
            int cad = cadena[cont];
            if (cont < longitud)
            {
                if (cadena[cont] == '-')
                {
                    cont++;
                    Q1();
                }
                else if (Char.IsNumber(cadena[cont]))
                {
                    cont++;
                    Q2();
                }
                else if (cad == 34)
                {
                    cont++;
                    Q3();
                }
                else if (cadena[cont] == '+')
                {
                    cont++;
                    Q4();
                }
                else if (cadena[cont] == '*' || cadena[cont] == '(' || cadena[cont] == ')' || cadena[cont] == ';') //por el momento omitimos la transición char
                {
                    cont++;
                    Q5();
                }
                else if (cadena[cont] == '/')
                {
                    cont++;
                    Q6();
                }
                else if (cadena[cont] == '=' || cadena[cont] == '!')
                {
                    cont++;
                    Q7();
                }
                else if (cadena[cont] == '<' || cadena[cont] == '>')
                {
                    cont++;
                    Q8();
                }
                else if (cadena[cont] == '|')
                {
                    cont++;
                    Q9();
                }
                else if (cadena[cont] == '&')
                {
                    cont++;
                    Q10();
                }
                else if (Char.IsLetter(cadena[cont]) || cadena[cont] == '_')
                {
                    cont++;
                    Q11();
                }
            }
        }

        public void Q1()
        {
            Console.WriteLine("Q1");
            aceptacion = true;
            if (cont < longitud)
            {
                if (Char.IsNumber(cadena[cont]))
                {
                    cont++;
                    Q2();
                }
                if (cadena[cont] == '-')
                {
                    cont++;
                    Q5();
                }
                else
                {
                    aceptacion = false;
                }
            }
        }

        public void Q2()
        {
            Console.WriteLine("Q2");
            aceptacion = true;
            if (cont < longitud)
            {
                if (Char.IsNumber(cadena[cont]))
                {
                    cont++;
                    Q2();
                }
                else if (cadena[cont] == '.')
                {
                    cont++;
                    Q12();
                }
                else
                {
                    aceptacion = false;
                }
            }
        }

        public void Q3()
        {
            Console.WriteLine("Q3");
            aceptacion = false;
            int cad = cadena[cont];
            if (cont < longitud)
            {
                if ((cad >= 0 && cad < 34) || (cad > 34 && cad <= 255))
                {
                    cont++;
                    Q3();
                }
                else if (cad == 34)
                {
                    cont++;
                    Q5();
                }
            }
        }

        public void Q4()
        {
            Console.WriteLine("Q4");
            aceptacion = true;
            if (cont < longitud)
            {
                if (cadena[cont] == '+')
                {
                    cont++;
                    Q5();
                }
                else
                {
                    aceptacion = false;
                }
            }
        }

        public void Q5()
        {
            Console.WriteLine("Q5");
            aceptacion = true;
        }

        public void Q6()
        {
            Console.WriteLine("Q6");
            aceptacion = true;
            if (cont < longitud)
            {
                if (cadena[cont] == '*')
                {
                    cont++;
                    Q13();
                }
                else if (cadena[cont] == '/')
                {
                    cont++;
                    Q17();
                }
                else
                {
                    aceptacion = false;
                }
            }
        }

        public void Q7()
        {
            Console.WriteLine("Q7");
            aceptacion = true;
            if (cont < longitud)
            {
                if (cadena[cont] == '=')
                {
                    cont++;
                    Q5();
                }
                else
                {
                    aceptacion = false;
                }
            }
        }

        public void Q8()
        {
            Console.WriteLine("Q8");
            aceptacion = true;
            if (cont < longitud)
            {
                if (cadena[cont] == '=')
                {
                    cont++;
                    Q5();
                }
                else
                {
                    aceptacion = false;
                }
            }
        }

        public void Q9()
        {
            Console.WriteLine("Q9");
            aceptacion = false;
            if (cont < longitud)
            {
                if (cadena[cont] == '|')
                {
                    cont++;
                    Q5();
                }
            }
        }

        public void Q10()
        {
            Console.WriteLine("Q10");
            aceptacion = false;
            if (cont < longitud)
            {
                if (cadena[cont] == '&')
                {
                    cont++;
                    Q5();
                }
            }
        }

        public void Q11()
        {
            Console.WriteLine("Q11");
            aceptacion = true;
            if (cont < longitud)
            {
                if (Char.IsLetter(cadena[cont]) || cadena[cont] == '_')
                {
                    cont++;
                    Q11();
                }
                else
                {
                    aceptacion = false;
                }
            }
        }

        public void Q12()
        {
            Console.WriteLine("Q12");
            aceptacion = false;
            if (cont < longitud)
            {
                if (Char.IsNumber(cadena[cont]))
                {
                    cont++;
                    Q15();
                }
            }
        }

        public void Q13()
        {
            Console.WriteLine("Q13");
            aceptacion = false;
            if (cont < longitud)
            {
                if (cadena[cont] != '/' && cadena[cont] != '*')
                {
                    cont++;
                    Q13();
                }
                else if (cadena[cont] == '*')
                {
                    cont++;
                    Q16();
                }
            }
        }

        public void Q15()
        {
            Console.WriteLine("Q15");
            aceptacion = true;
            if(cont < longitud)
            {
                if (Char.IsNumber(cadena[cont]))
                {
                    cont++;
                    Q15();
                }
                else
                {
                    aceptacion = false;
                }
            }
        }

        public void Q16()
        {
            Console.WriteLine("Q16");
            aceptacion = false;
            if(cont < longitud)
            {
                if(cadena[cont] == '/')
                {
                    cont++;
                    Q5();
                }
            }
        }

        public void Q17()
        {
            Console.WriteLine("Q17");
            aceptacion = false;
            if(cont < longitud)
            {
                if(cadena[cont] != '\n')
                {
                    cont++;
                    Q17();
                }
                else if (cadena[cont] == '\n')
                {
                    cont++;
                    Q5();
                }
            }
        }

    }
}
