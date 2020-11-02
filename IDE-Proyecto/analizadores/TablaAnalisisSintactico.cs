using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE_Proyecto.analizadores
{
    class TablaAnalisisSintactico
    {

        private List<String>[,] tabla = new List<String>[43, 36];

        public TablaAnalisisSintactico()
        {
            inicializarTabla();
        }

        public List<String>[,] Tabla
        {
            get
            {
                return tabla;
            }
        }

        private void inicializarTabla()
        {

            for(int i = 0; i < 43; i++)
            {
                for(int j = 0; j < 36; j++)
                {
                    tabla[i, j] = new List<String>();
                }
            }

            
            tabla[0, 0].Add("Texto");
            tabla[0, 0].Add("SimboloInicial");
            tabla[0, 0].Add("PRprincipal");

            tabla[1, 1].Add("{");
            tabla[1, 1].Add(")");
            tabla[1, 1].Add("(");

            tabla[2, 4].Add("}");
            tabla[2, 5].Add("Texto");
            tabla[2, 5].Add("VariablesL");
            tabla[2, 6].Add("Texto");
            tabla[2, 6].Add("DeclaVariable");
            tabla[2, 15].Add("Texto");
            tabla[2, 15].Add("Impresion");
            tabla[2, 21].Add("Texto");
            tabla[2, 21].Add("Lectura");
            tabla[2, 22].Add("Texto");
            tabla[2, 22].Add("Condicion");
            tabla[2, 30].Add("Texto");
            tabla[2, 30].Add("CicloHM");
            tabla[2, 31].Add("Texto");
            tabla[2, 31].Add("CicloM");
            tabla[2, 32].Add("Texto");
            tabla[2, 32].Add("CicloF");

            tabla[3, 6].Add(";");
            tabla[3, 6].Add("Incrementable");
            tabla[3, 6].Add("TokId");

            tabla[4, 7].Add("++");
            tabla[4, 8].Add("--");
            tabla[4, 23].Add("TipoValor");
            tabla[4, 23].Add("=");

            tabla[5, 5].Add("id");
            tabla[5, 5].Add("idVar");
            tabla[5, 5].Add("PRDatoPrimi");

            tabla[6, 9].Add("id");
            tabla[6, 9].Add("idVar");
            tabla[6, 9].Add(",");
            tabla[6, 10].Add(";");

            tabla[7, 6].Add("valor");
            tabla[7, 6].Add("TokId");

            tabla[8, 9].Add("e");
            tabla[8, 10].Add("e");
            tabla[8, 23].Add("TipoValor");
            tabla[8, 23].Add("=");

            tabla[9, 1].Add("Suma");
            tabla[9, 6].Add("Suma");
            tabla[9, 11].Add("cadena");
            tabla[9, 13].Add("char");
            tabla[9, 14].Add("Suma");
            tabla[9, 17].Add("Suma");
            tabla[9, 28].Add("PRBooleana");

            tabla[10, 1].Add("Suma'");
            tabla[10, 1].Add("Multi");
            tabla[10, 6].Add("Suma'");
            tabla[10, 6].Add("Multi");
            tabla[10, 14].Add("Suma'");
            tabla[10, 14].Add("Multi");
            tabla[10, 17].Add("Suma'");
            tabla[10, 17].Add("Multi");

            tabla[11, 2].Add("e");
            tabla[11, 9].Add("e");
            tabla[11, 10].Add("e");
            tabla[11, 16].Add("Suma'");
            tabla[11, 16].Add("Multi");
            tabla[11, 16].Add("+");
            tabla[11, 17].Add("Suma'");
            tabla[11, 17].Add("Multi");
            tabla[11, 17].Add("-");
            tabla[11, 26].Add("e");
            tabla[11, 27].Add("e");

            tabla[12, 1].Add("Multi'");
            tabla[12, 1].Add("Pot");
            tabla[12, 6].Add("Multi'");
            tabla[12, 6].Add("Pot");
            tabla[12, 14].Add("Multi'");
            tabla[12, 14].Add("Pot");
            tabla[12, 17].Add("Multi'");
            tabla[12, 17].Add("Pot");

            tabla[13, 2].Add("e");
            tabla[13, 9].Add("e");
            tabla[13, 10].Add("e");
            tabla[13, 16].Add("e");
            tabla[13, 17].Add("e");
            tabla[13, 18].Add("Multi'");
            tabla[13, 18].Add("Pot");
            tabla[13, 18].Add("/");
            tabla[13, 19].Add("Multi'");
            tabla[13, 19].Add("Pot");
            tabla[13, 19].Add("*");
            tabla[13, 26].Add("e");
            tabla[13, 27].Add("e");

            tabla[14, 1].Add("Pot'");
            tabla[14, 1].Add("Unar");
            tabla[14, 6].Add("Pot'");
            tabla[14, 6].Add("Unar");
            tabla[14, 14].Add("Pot'");
            tabla[14, 14].Add("Unar");
            tabla[14, 17].Add("Pot'");
            tabla[14, 17].Add("Unar");

            tabla[15, 2].Add("e");
            tabla[15, 9].Add("e");
            tabla[15, 10].Add("e");
            tabla[15, 16].Add("e");
            tabla[15, 17].Add("e");
            tabla[15, 18].Add("e");
            tabla[15, 19].Add("e");
            tabla[15, 20].Add("Pot");
            tabla[15, 20].Add("^");
            tabla[15, 26].Add("e");
            tabla[15, 27].Add("e");

            tabla[16, 1].Add("Elem");
            tabla[16, 6].Add("Elem");
            tabla[16, 14].Add("Elem");
            tabla[16, 17].Add("-");
            tabla[16, 17].Add("Elem");

            tabla[17, 1].Add(")");
            tabla[17, 1].Add("Suma");
            tabla[17, 1].Add("(");
            tabla[17, 6].Add("TokId");
            tabla[17, 14].Add("Num");

            tabla[18, 15].Add("ValImprimir");
            tabla[18, 15].Add("PRimprimir");

            tabla[19, 1].Add("Append");
            tabla[19, 1].Add("Imprimir");
            tabla[19, 1].Add("(");

            tabla[20, 6].Add("TokId");
            tabla[20, 11].Add("cadena");
            tabla[20, 13].Add("char");
            tabla[20, 14].Add("Num");

            tabla[21, 2].Add(";");
            tabla[21, 2].Add(")");
            tabla[21, 16].Add("Append");
            tabla[21, 16].Add("Imprimir");
            tabla[21, 16].Add("+");

            tabla[22, 21].Add(";");
            tabla[22, 21].Add("ValLeer");
            tabla[22, 21].Add("PRleer");

            tabla[23, 1].Add(")");
            tabla[23, 1].Add("TokId");
            tabla[23, 1].Add("(");

            tabla[24, 22].Add("Cond2");
            tabla[24, 22].Add("DescCondicion");
            tabla[24, 22].Add("PRSI");

            tabla[25, 1].Add("CuerpoDescCond");
            tabla[25, 1].Add("ValCondicion");
            
            tabla[26, 3].Add("Texto");
            tabla[26, 3].Add("{");

            tabla[27, 4].Add("e");
            tabla[27, 5].Add("e");
            tabla[27, 6].Add("e");
            tabla[27, 15].Add("e");
            tabla[27, 21].Add("e");
            tabla[27, 22].Add("e");
            tabla[27, 24].Add("Cond2");
            tabla[27, 24].Add("DescCondicion");
            tabla[27, 24].Add("PRSINO_SI");
            tabla[27, 25].Add("CuerpoDescCond");
            tabla[27, 25].Add("PRSINO");
            tabla[27, 30].Add("e");
            tabla[27, 31].Add("e");
            tabla[27, 32].Add("e");

            tabla[28, 1].Add(")");
            tabla[28, 1].Add("DescValCondicion");
            tabla[28, 1].Add("(");

            tabla[29, 1].Add("CondicionantePlus");
            tabla[29, 1].Add("Condicionante");
            tabla[29, 1].Add("SigDif");
            tabla[29, 2].Add("e");
            tabla[29, 6].Add("CondicionantePlus");
            tabla[29, 6].Add("Condicionante");
            tabla[29, 6].Add("SigDif");
            tabla[29, 14].Add("CondicionantePlus");
            tabla[29, 14].Add("Condicionante");
            tabla[29, 14].Add("SigDif");
            tabla[29, 17].Add("CondicionantePlus");
            tabla[29, 17].Add("Condicionante");
            tabla[29, 17].Add("SigDif");
            tabla[29, 28].Add("CondicionantePlus");
            tabla[29, 28].Add("Condicionante");
            tabla[29, 28].Add("SigDif");
            tabla[29, 29].Add("CondicionantePlus");
            tabla[29, 29].Add("Condicionante");
            tabla[29, 29].Add("SigDif");

            tabla[30, 1].Add("Suma");
            tabla[30, 1].Add("OpRel");
            tabla[30, 1].Add("Suma");
            tabla[30, 6].Add("Suma");
            tabla[30, 6].Add("OpRel");
            tabla[30, 6].Add("Suma");
            tabla[30, 14].Add("Suma");
            tabla[30, 14].Add("OpRel");
            tabla[30, 14].Add("Suma");
            tabla[30, 17].Add("Suma");
            tabla[30, 17].Add("OpRel");
            tabla[30, 17].Add("Suma");
            tabla[30, 28].Add("PRBooleana");

            tabla[31, 1].Add("e");
            tabla[31, 6].Add("e");
            tabla[31, 14].Add("e");
            tabla[31, 17].Add("e");
            tabla[31, 28].Add("e");
            tabla[31, 29].Add("SigDif");
            tabla[31, 29].Add("!");

            tabla[32, 2].Add("e");
            tabla[32, 26].Add("DescValCondicion");
            tabla[32, 26].Add("OpLogico");

            tabla[33, 31].Add("CuerpoDescCond");
            tabla[33, 31].Add("ValCondicion");
            tabla[33, 31].Add("PRMIENTRAS");

            tabla[34, 30].Add("ValCondicion");
            tabla[34, 30].Add("DescCicloHM");

            tabla[35, 30].Add("PRMIENTRAS");
            tabla[35, 30].Add("CuerpoDescCond");
            tabla[35, 30].Add("PRHACER");

            tabla[36, 32].Add("CuerpoDescCond");
            tabla[36, 32].Add("EstructCicloF");

            tabla[37, 32].Add("EstructIncremento");
            tabla[37, 32].Add("EstructHasta");
            tabla[37, 32].Add("EstructDesde");

            tabla[38, 32].Add("desde");
            tabla[38, 32].Add("PRDESDE");

            tabla[39, 33].Add("hasta");
            tabla[39, 33].Add("PRHASTA");

            tabla[40, 34].Add("Num");
            tabla[40, 34].Add("PRINCREMENTO");

            tabla[41, 6].Add("Num");
            tabla[41, 6].Add("=");
            tabla[41, 6].Add("TokId");

            tabla[42, 6].Add("Num");
            tabla[42, 6].Add("OpRel");
            tabla[42, 6].Add("TokId");

        }

    }
}
