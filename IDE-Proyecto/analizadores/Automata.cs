using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE_Proyecto.analizadores
{
    /// <summary>
    /// Clase encargada de manejar todo lo relacionado con la validación o descarte de tokens recibidos
    /// El autómata ha sido programado por medio de metodos, por lo cual:
    /// Cada método es un éstado del autómata
    /// Las transiciones se dan en las condiciones que cada método posee
    /// </summary>
    class Automata
    {

        private int cont, longitud;
        private String cadenaIngresada, color = "Black";
        private String azulOscuro = "RoyalBlue";
        private bool aceptacion;
        private char[] cadena;
        private List<String> PalabrasReservadas;
       
        /// <summary>
        /// Constructor del autómata
        /// </summary>
        public Automata()
        {
            
            Inicializacion();
            

        }

        /// <summary>
        /// Método encargado de comprobar si el resultado final de las trancisiones entre estados es verdadero
        /// </summary>
        /// <param name="cadenaIngresada">token</param>
        /// <returns></returns>
        public bool Comprobar(String cadenaIngresada)
        {
            this.cadenaIngresada = cadenaIngresada;
            longitud = cadenaIngresada.Length;
            cadena = cadenaIngresada.ToCharArray();
            cont = 0;
            aceptacion = false;
            color = "Black";

            Console.WriteLine("\n\nPara la cadena: " + cadenaIngresada);
            Q0();

            return aceptacion;
        }

        /// <summary>
        /// Inicializa las palabras reservadas que tendrá el lenguaje
        /// </summary>
        private void Inicializacion()
        {
            PalabrasReservadas = new List<String>();
            PalabrasReservadas.Add("entero");
            PalabrasReservadas.Add("decimal");
            PalabrasReservadas.Add("cadena");
            PalabrasReservadas.Add("booleano");
            PalabrasReservadas.Add("carácter");
            PalabrasReservadas.Add("verdadero");
            PalabrasReservadas.Add("falso");
            PalabrasReservadas.Add("SI");
            PalabrasReservadas.Add("SINO");
            PalabrasReservadas.Add("SINO_SI");
            PalabrasReservadas.Add("MIENTRAS");
            PalabrasReservadas.Add("HACER");
            PalabrasReservadas.Add("DESDE");
            PalabrasReservadas.Add("HASTA");
            PalabrasReservadas.Add("INCREMENTO");
        }

        private void Q0()
        {
            Console.WriteLine("Q0");
            aceptacion = false;
            if (cont < longitud)
            {
                int cad = cadena[cont];
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
                    if (cadena[cont] != ';')
                    {
                        color = azulOscuro;
                    }
                    else
                    {
                        color = "HotPink";
                    }
                    cont++;
                    Q5();
                }
                else if (cadena[cont] == '/')
                {
                    color = azulOscuro;
                    cont++;
                    Q6();
                }
                else if (cadena[cont] == '=' || cadena[cont] == '!')
                {
                    if (cadena[cont] == '=')
                    {
                        color = "HotPink";
                    }
                    else
                    {
                        color = azulOscuro;
                    }
                    cont++;
                    Q7();
                }
                else if (cadena[cont] == '<' || cadena[cont] == '>')
                {
                    color = azulOscuro;
                    cont++;
                    Q8();
                }
                else if (cadena[cont] == '|')
                {
                    color = azulOscuro;
                    cont++;
                    Q9();
                }
                else if (cadena[cont] == '&')
                {
                    color = azulOscuro;
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

        private void Q1()
        {
            Console.WriteLine("Q1");
            aceptacion = true;
            color = azulOscuro;
            if (cont < longitud)
            {
                if (Char.IsNumber(cadena[cont]))
                {
                    cont++;
                    Q2();
                }
                else if (cadena[cont] == '-')
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

        private void Q2()
        {
            Console.WriteLine("Q2");
            aceptacion = true;
            color = "BlueViolet";
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

        private void Q3()
        {
            Console.WriteLine("Q3");
            aceptacion = false;
            color = "LightSlateGray";
            if (cont < longitud)
            {
                int cad = cadena[cont];
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

        private void Q4()
        {
            Console.WriteLine("Q4");
            aceptacion = true;
            color = azulOscuro;
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

        private void Q5()
        {
            Console.WriteLine("Q5");
            aceptacion = true;
            if(cont < longitud)
            {
                aceptacion = false;
                color = "Black";
            }
        }

        private void Q6()
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

        private void Q7()
        {
            Console.WriteLine("Q7");
            aceptacion = true;
            if (cont < longitud)
            {
                if (cadena[cont] == '=')
                {
                    color = azulOscuro;
                    cont++;
                    Q5();
                }
                else
                {
                    aceptacion = false;
                }
            }
        }

        private void Q8()
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

        private void Q9()
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

        private void Q10()
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

        private void Q11()
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
            else
            {
                foreach(String element in PalabrasReservadas)
                {
                    if (element.Equals(cadenaIngresada))
                    {
                        color = "Green";
                        if(element.Equals("verdadero") || element.Equals("falso"))
                        {
                            color = "DarkOrange";
                        }
                    }
                }
            }
        }

        private void Q12()
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

        private void Q13()
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

        private void Q15()
        {
            Console.WriteLine("Q15");
            aceptacion = true;
            color = "LightSkyBlue";
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

        private void Q16()
        {
            Console.WriteLine("Q16");
            aceptacion = false;
            color = "Red";
            if(cont < longitud)
            {
                if(cadena[cont] == '/')
                {
                    cont++;
                    Q5();
                }
            }
        }

        private void Q17()
        {
            Console.WriteLine("Q17");
            aceptacion = false;
            color = "Red";
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

        public bool Aceptacion
        {
            get
            {
                return aceptacion;
            }
        }

        public String Color
        {
            get
            {
                if (aceptacion == true)
                    return color;
                else
                    return "Black";
            }
        }

    }
}
