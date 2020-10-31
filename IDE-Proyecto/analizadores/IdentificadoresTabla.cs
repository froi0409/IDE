using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE_Proyecto.analizadores
{
    class IdentificadoresTabla
    {

        private String[] fila = new String[43];
        private String[] columna = new String[36];

        public IdentificadoresTabla()
        {
            inicializacionFilas();
            inicializacionColumnas();
        }

        public String[] Fila
        {
            get
            {
                return fila;
            }
        }

        public String[] Columna
        {
            get
            {
                return columna;
            }
        }

        private void inicializacionFilas()
        {
            fila[0] = "Codigo";
            fila[1] = "SimboloInicial";
            fila[2] = "Texto";
            fila[3] = "DeclaVariable";
            fila[4] = "Incrementable";
            fila[5] = "VariablesL";
            fila[6] = "id";
            fila[7] = "idVar";
            fila[8] = "valor";
            fila[9] = "TipoValor";
            fila[10] = "Suma";
            fila[11] = "Suma'";
            fila[12] = "Multi";
            fila[13] = "Multi'";
            fila[14] = "Pot";
            fila[15] = "Pot'";
            fila[16] = "Unar";
            fila[17] = "Elem";
            fila[18] = "Impresion";
            fila[19] = "ValImprimir";
            fila[20] = "Imprimir";
            fila[21] = "Append";
            fila[22] = "Lectura";
            fila[23] = "ValLeer";
            fila[24] = "Condicion";
            fila[25] = "DescCondicion";
            fila[26] = "CuerpoDescCond";
            fila[27] = "Cond2";
            fila[28] = "ValCondicion";
            fila[29] = "DescValCondicion";
            fila[30] = "Condicionante";
            fila[31] = "SigDif";
            fila[32] = "CondicionantePlus";
            fila[33] = "CicloM";
            fila[34] = "CicloHM";
            fila[35] = "DescCicloHM";
            fila[36] = "CicloF";
            fila[37] = "EstructCicloF";
            fila[38] = "EstructDesde";
            fila[39] = "EstructHasta";
            fila[40] = "EstructIncremento";
            fila[41] = "desde";
            fila[42] = "hasta";
        }

        private void inicializacionColumnas()
        {
            columna[0] = "PRprincipal";
            columna[1] = "(";
            columna[2] = ")";
            columna[3] = "{";
            columna[4] = "}";
            columna[5] = "PRDatoPrimi";
            columna[6] = "TokId";
            columna[7] = "++";
            columna[8] = "--";
            columna[9] = ",";
            columna[10] = ";";
            columna[11] = "cadena";
            columna[12] = "booleano";
            columna[13] = "char";
            columna[14] = "Num";
            columna[15] = "PRimprimir";
            columna[16] = "+";
            columna[17] = "-";
            columna[18] = "/";
            columna[19] = "*";
            columna[20] = "^";
            columna[21] = "PRleer";
            columna[22] = "PRSI";
            columna[23] = "=";
            columna[24] = "PRSINO_SI";
            columna[25] = "PRSINO";
            columna[26] = "OpLogico";
            columna[27] = "OpRel";
            columna[28] = "PRBooleana";
            columna[29] = "!";
            columna[30] = "PRHACER";
            columna[31] = "PRMIENTRAS";
            columna[32] = "PRDESDE";
            columna[33] = "PRHASTA";
            columna[34] = "PRINCREMENTO";
            columna[35] = "$";
        }

    }
}
