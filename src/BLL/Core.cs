using System;
using System.Linq;
using System.Configuration;

namespace Arquimedes.BLL
{
    public static class Core
    {
        public static int daysToEndMonth()
        {
            var hoje = DateTime.Now.Date.AddDays(-1);
            var ultimoDiaDoMes = hoje.AddDays(-(hoje.Day - 1)).AddMonths(1).AddDays(-1);
            var primeiroDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var Feriados = Convert.ToInt32(ConfigurationManager.AppSettings["FeriadosMes"]);
            var diasFaltantes = ultimoDiaDoMes.AddDays(hoje.Day * -1).Day - FinsDeSemana() - Feriados;

            return diasFaltantes;
        }

        public static string HourParse(string hour)
        {
            if (!hour.Contains(':'))
            {
                hour = hour + ":00";
            }
            return hour;
        }

        public static decimal HourToDecimal(string hour)
        {
            return Convert.ToDecimal(Convert.ToDecimal(hour.Split(':')[0]) + Convert.ToDecimal(TimeSpan.Parse("00:" + hour.Split(':')[1]).TotalHours));
        }

        public static string DecimalToHour(decimal hour)
        {
            var h = Convert.ToDouble(hour);
            var time = TimeSpan.FromHours(h).ToString("mm");

            return Convert.ToInt32(h.ToString().Split(',')[0]).ToString() + ":" + time;
        }

        public static int FinsDeSemana()
        {
            var _data = DateTime.Now;
            int contador = 1;

            DateTime PrimeiroDiadoMes = DateTime.Parse("01" + _data.ToString("/ MM / yyyy"));
            DateTime PrimeiroDiadoProximoMes = PrimeiroDiadoMes.AddMonths(1);
            var UltimoDiadoMes = PrimeiroDiadoProximoMes.AddDays(-1).Day;

            for (int i = _data.Day; i < UltimoDiadoMes; i++)
            {
                DateTime diaCorrido = DateTime.Parse(i.ToString() + _data.ToString("/ MM / yyyy"));

                if (diaCorrido.DayOfWeek == DayOfWeek.Saturday)
                    contador++;
                else if (diaCorrido.DayOfWeek == DayOfWeek.Sunday)
                    contador++;
            }

            return contador;
        }
    }
}
