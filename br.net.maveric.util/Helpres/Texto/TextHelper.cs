using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace br.net.maveric.util.Helpres.Texto
{
    public static class TextHelper
    {
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public static string Resumo(string txt)
        {
            txt = StripHTML(txt);

            txt = System.Net.WebUtility.HtmlDecode(txt);

            if (txt.Length > 140)
            {
                return txt.Substring(0, 140) + "...";
            }
            else
            {
                return txt;
            }
        }

        public static string Descicao(string descricao, int maxCarctres)
        {
            if (descricao.Length > maxCarctres)
            {
                int corata = (descricao.Length - maxCarctres) * -1;
                return descricao.Substring(0, maxCarctres) + "...";
            }
            else
            {
                return descricao;
            }
        }
    }
}
