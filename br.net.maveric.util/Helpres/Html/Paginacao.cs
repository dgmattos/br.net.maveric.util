using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.net.maveric.util.Helpres.Html
{
    public class Paginacao
    {
        public int PaginaAtual { get; set; }
        public int Registros { get; set; }
        public int NumeroPaginas { get; set; }
        public int ItensPorPagina { get; set; }


        private string HtmlButton = "<button data-pagination-button=\"true\" value=\"%PAGE_Value%\" type=\"button\" data-submit=\"%FROM_SELETOR%\" class=\"btn btn-%BTN_CLASS%\">%PAGE_Label%</button>";
        private string HtmlPaginacao = "";


        public Paginacao(int totalItens, int PaginaAtual)
        {

            if (totalItens <= 20)
            {
                Inicializa(20, totalItens, PaginaAtual);
            }
            else
            {
                Inicializa(8, totalItens, PaginaAtual);
            }

        }

        public Paginacao(int maxItemPag, int totalItens, int PaginaAtual)
        {
            Inicializa(maxItemPag, totalItens, PaginaAtual);
        }

        private void Inicializa(int maxItemPag, int totalItens, int PaginaAtual)
        {
            ItensPorPagina = maxItemPag;
            NumeroPaginas = totalItens / ItensPorPagina;

            this.ItensPorPagina = ItensPorPagina;

            if (NumeroPaginas * NumeroPaginas < totalItens)
            {
                NumeroPaginas = NumeroPaginas + 1;
            }

            this.PaginaAtual = PaginaAtual;
            Registros = totalItens;
        }

        public string ShowPaginacao(string FormSeletor)
        {
            HtmlPaginacao = "<div class=\"btn-group\" role=\"group\" aria-label=\"Páginas\">";


            if (PaginaAtual > 1)
            {
                HtmlPaginacao += ConstroiBotao(FormSeletor, "secondary", "<<", 1 + "");
                HtmlPaginacao += ConstroiBotao(FormSeletor, "secondary", "<", (PaginaAtual - 1) + "");
            }


            if (NumeroPaginas > 7 && PaginaAtual > (7 / 2))
            {
                for (int i = PaginaAtual - 3; i < PaginaAtual; i++)
                {
                    HtmlPaginacao += ConstroiBotao(FormSeletor, "secondary", i + "", i + "");
                }

                HtmlPaginacao += ConstroiBotao(FormSeletor, "primary", PaginaAtual + "", PaginaAtual + "");

                for (int i = PaginaAtual + 1; i <= PaginaAtual + 3 && i <= NumeroPaginas; i++)
                {
                    HtmlPaginacao += ConstroiBotao(FormSeletor, "secondary", i + "", i + "");
                }
            }
            else
            {
                for (int i = 1; i <= 7 && i <= NumeroPaginas; i++)
                {
                    string classe = "secondary";

                    if (i == PaginaAtual)
                    {
                        classe = "primary";
                    }
                    HtmlPaginacao += ConstroiBotao(FormSeletor, classe, i + "", i + "");
                }
            }






            if (PaginaAtual < NumeroPaginas)
            {
                HtmlPaginacao += ConstroiBotao(FormSeletor, "secondary", ">", (PaginaAtual + 1) + "");
                HtmlPaginacao += ConstroiBotao(FormSeletor, "secondary", ">>", NumeroPaginas + "");
            }


            HtmlPaginacao += "</div>";
            return HtmlPaginacao;
        }

        private string ConstroiBotao(string FormSeletor, string BtnClass, string PaginaLabel, string PaginaValue)
        {

            string btn = HtmlButton.Replace("%FROM_SELETOR%", FormSeletor);
            btn = btn.Replace("%BTN_CLASS%", BtnClass);
            btn = btn.Replace("%PAGE_Label%", PaginaLabel);
            btn = btn.Replace("%PAGE_Value%", PaginaValue);

            return btn;
        }
    }
}
