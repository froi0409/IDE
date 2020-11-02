using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE_Proyecto.analizadores
{
    class Token
    {

        private String tipo;
        private int fila;
        private int columna;

        public Token(String tipo, int fila, int columna)
        {
            this.tipo = tipo;
            this.fila = fila;
            this.columna = columna;
        }

        public String Tipo
        {
            get
            {
                return tipo;
            }
        }

        public int Fila
        {
            get
            {
                return fila;
            }
        }

        public int Columna
        {
            get
            {
                return columna;
            }
        }

    }
}
