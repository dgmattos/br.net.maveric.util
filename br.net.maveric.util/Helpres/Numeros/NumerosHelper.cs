using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.net.maveric.util.Helpres.Numeros
{
    public static class NumerosHelper
    {
        public static string VariacaoPercentual(int v1, int v2)
        {
            if (v1 == 0)
            {
                v1 = 1;
            }

            if (v2 == 0)
            {
                v2 = 1;
            }
            decimal variacao = 0;
            int v3 = v1 - v2;
            variacao = (decimal)v3 / (decimal)v2;
            variacao = ((variacao) * 100);
            string v4 = String.Format("{0:N2}", variacao);
            return v4 + "%";
        }

        public static string VariacaoIcone(string valor)
        {
            valor = valor.Replace("%", "");
            decimal v = decimal.Parse(valor);
            if (v < 0)
            {
                return "&darr;";
            }
            else if (v > 0)
            {
                return "&uarr;";
            }
            else
            {
                return "";
            }
        }
    }
}
