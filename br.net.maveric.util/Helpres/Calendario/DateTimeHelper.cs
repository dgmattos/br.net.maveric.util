using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.net.maveric.util.Helpres.Calendario
{
    public static class DateTimeHelper
    {
        public static string Formatar(DateTime? data, string mascara = "dd/MM/yyyy", string casenull = "")
        {
            if (data == null)
            {
                return casenull;
            }
            else
            {
                return ((DateTime)data).ToString(@"" + mascara + "") + "";
            }
        }

        public static string Formatar(DateTime data, string mascara = "dd/MM/yyyy")
        {
            return data.ToString(@"" + mascara + "") + "";
        }

        public static string QuantoTempo(DateTime data)
        {
            DateTime hoje = DateTime.Now;

            TimeSpan diferenca = hoje - data;

            StringBuilder retorno = new StringBuilder(string.Empty);

            int anos, meses, dias, horas, minutos, segundos;

            anos = GetYears(diferenca);

            meses = GetMonths(diferenca);

            dias = diferenca.Days;

            horas = diferenca.Hours;
            minutos = diferenca.Minutes;
            segundos = diferenca.Seconds;

            if (diferenca.Days <= 15)
            {
                if (anos > 0)
                {
                    dias = dias - (anos * 365);
                }

                if (meses > 0)
                {
                    dias = dias - (meses * 30);
                }

                if (anos > 0 && meses > 0)
                {
                    retorno.Append(anos + " " + ((anos > 1) ? "anos" : "ano"));
                    retorno.Append(" e " + meses + ((meses > 1) ? " mêses" : " mês"));
                }
                else
                {
                    if (meses > 0)
                    {
                        retorno.Append(" e ");
                        retorno.Append(meses + ((meses > 1) ? " mêses" : " mês"));

                        if (dias > 0)
                        {
                            retorno.Append(" e ");
                            retorno.Append(dias + ((dias > 1) ? " dias" : " dia"));
                        }
                    }
                    else
                    {
                        if (dias > 0)
                        {
                            retorno.Append(dias + ((dias > 1) ? " dias" : " dia"));
                        }

                        if (horas > 0)
                        {
                            if (dias > 0)
                            {
                                retorno.Append(" e ");
                            }

                            retorno.Append("" + ((horas > 1) ? horas + " horas" : horas + " hora"));
                        }

                        if (minutos > 0 && dias == 0)
                        {
                            if (dias > 0 || horas > 0)
                            {
                                retorno.Append(" e ");
                            }
                            retorno.Append("" + ((minutos > 1) ? minutos + " minutos" : minutos + " minuto"));
                        }

                        if (segundos > 0 && (horas == 0 && minutos == 0))
                        {
                            if (dias > 0 || horas > 0 || minutos > 0)
                            {
                                retorno.Append(" e ");
                            }
                            retorno.Append("" + ((segundos > 1) ? segundos + " segundos" : segundos + " segundo"));
                        }
                    }
                }

                if (retorno.Length <= 0)
                {
                    retorno.Append(" Agora.");
                }
                else
                {
                    retorno.Append(" atrás.");
                }
            }
            else
            {
                retorno.Append(data.Day + " de ");
                retorno.Append(CalendarioHelper.NomeMesSmall(data.Month) + " de ");
                retorno.Append(data.Year + ".");
            }

            return retorno.ToString();

        }


        public static int GetYears(this TimeSpan timespan)
        {
            return (int)(timespan.Days / 365.2425);
        }
        public static int GetMonths(this TimeSpan timespan)
        {
            return (int)(timespan.Days / 30.436875);
        }

        public static string Saudacao()
        {
            DateTime hora = DateTime.Now;

            if (hora.Hour >= 4 && hora.Hour <= 11)
            {
                return "bom dia.";

            }
            else if (hora.Hour >= 12 && hora.Hour <= 18)
            {
                return "boa tarde.";
            }
            else if (hora.Hour >= 19 && hora.Hour <= 3)
            {
                return "boa tarde.";
            }
            else
            {
                return "tudo bem com você?";
            }
        }
    }
}
