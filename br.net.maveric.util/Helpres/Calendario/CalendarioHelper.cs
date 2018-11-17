using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.net.maveric.util.Helpres.Calendario
{
    public class CalendarioHelper
    {

        public static string NomeDia(int numeroDia)
        {
            switch (numeroDia)
            {
                case 0:
                    return "Domingo";
                case 1:
                    return "Segunda";
                case 2:
                    return "Terça";
                case 3:
                    return "Quarta";
                case 4:
                    return "Quinta";
                case 5:
                    return "Sexta";
                case 6:
                    return "Sábado";
                default:
                    return "Inválido ";
            }
        }

        public static string NomeDia(string numeroDia)
        {
            switch (numeroDia)
            {
                case "Sunday":
                    return "Domingo";
                case "Monday":
                    return "Segunda";
                case "Tuesday":
                    return "Terça";
                case "Wednesday":
                    return "Quarta";
                case "Thursday":
                    return "Quinta";
                case "Friday":
                    return "Sexta";
                case "Saturday":
                    return "Sábado";
                default:
                    return "Inválido ";
            }
        }

        public static string NomeDiaSmall(int numeroDia)
        {
            switch (numeroDia)
            {
                case 0:
                    return "Dom";
                case 1:
                    return "Seg";
                case 2:
                    return "Ter";
                case 3:
                    return "Qua";
                case 4:
                    return "Qui";
                case 5:
                    return "Sex";
                case 6:
                    return "Sab";
                default:
                    return "Inválido " + numeroDia;
            }
        }


        public static string NomeMes(int numeroDia)
        {
            switch (numeroDia)
            {
                case 1:
                    return "Janeiro";
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
                case 12:
                    return "Dezembro";
                default:
                    return "Inválido";
            }
        }

        public static string NomeMesSmall(int numeroDia)
        {
            switch (numeroDia)
            {
                case 1:
                    return "Jan";
                case 2:
                    return "Fev";
                case 3:
                    return "Mar";
                case 4:
                    return "Abr";
                case 5:
                    return "Mai";
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Ago";
                case 9:
                    return "Set";
                case 10:
                    return "Out";
                case 11:
                    return "Nov";
                case 12:
                    return "Dez";
                default:
                    return "Inválido";
            }
        }

        public static DateTime PrimeiroDiaDoMes(DateTime data)
        {
            DateTime pdia = new DateTime(data.Year, data.Month, 1);
            return pdia;
        }

        public static DateTime PrimeiroDiaDoMes(string data)
        {
            DateTime dt;
            if (DateTime.TryParse(data, out dt))
            {
                return PrimeiroDiaDoMes(dt);
            }
            else
            {
                return PrimeiroDiaDoMes(DateTime.Now);
            }
        }


        public static DateTime UltimoDiaDoMes(DateTime data)
        {
            DateTime udi = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
            return udi;
        }

        public static DateTime UltimoDiaDoMes(string data)
        {
            DateTime dt;
            if (DateTime.TryParse(data, out dt))
            {
                return UltimoDiaDoMes(dt);
            }
            else
            {
                return UltimoDiaDoMes(DateTime.Now);
            }
        }

        public static DateTime PrimeiroDiaSemana(DateTime data)
        {
            if (DiaDaSemana(data) == 0)
            {
                return data;
            }
            else
            {
                return PrimeiroDiaSemana(data.AddDays(-1));
            }
        }


        public static DateTime PrimeiroDiaSemana(string data)
        {
            DateTime dt;
            if (DateTime.TryParse(data, out dt))
            {
                return PrimeiroDiaSemana(dt);
            }
            else
            {
                return PrimeiroDiaSemana(DateTime.Now);
            }
        }

        public static int DiaDaSemana(DateTime data)
        {
            return (int)data.DayOfWeek;
        }

        public static int DiasNoMes(DateTime data)
        {
            return DateTime.DaysInMonth(data.Year, data.Month);
        }

        public static string NomeMes(DateTime data)
        {
            return NomeMes(data.Month);
        }

        public static string NomeDia(DateTime data)
        {
            return NomeDia(DiaDaSemana(data));
        }

        public static string Ativo(DateTime data, DateTime data_sel)
        {
            if (data == DataDiaMesAno(data_sel))
            {
                return "bg-primary text-white";
            }
            else
            {
                return "";
            }
        }

        public static string Selecionado(DateTime data, DateTime data_sel, DateTime data_atual)
        {
            if (data == DataDiaMesAno(data_sel) && DataDiaMesAno(data_sel) != DataDiaMesAno(data_atual))
            {
                return "bg-secondary text-white";
            }
            else
            {
                return "";
            }
        }

        public static DateTime DataDiaMesAno(DateTime data, int hora, int minuto, int segundo)
        {
            return new DateTime(data.Year, data.Month, data.Day, hora, minuto, segundo);
        }

        public static DateTime DataDiaMesAno(DateTime data)
        {
            return DataDiaMesAno(data, 0, 0, 0);
        }

        public static String LegandaSemana(DateTime data)
        {
            DateTime primirodia = PrimeiroDiaDoMes(data);

            string leganda = "{0}ª Semana de " + NomeMes(data);

            DateTime dt = primirodia;

            int s = 0;

            while (dt <= data)
            {
                if (NomeDia(dt).Equals("Domingo"))
                {
                    s++;
                }

                dt = dt.AddDays(1);
            }

            if (s == 0)
            {
                s = 1;
            }

            return string.Format(leganda, s);
        }
    }
}
