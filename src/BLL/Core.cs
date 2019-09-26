using System;
using System.Linq;

namespace Arquimedes.BLL
{
    public static class Core
    {
        public static string FormataHora(this string hour)
        {
            if (!hour.Contains(':'))
            {
                hour = hour + ":00";
            }
            return hour;
        }

        public static decimal HoraParaDecimal(this string hour)
        {
            hour = hour.FormataHora();
            return Convert.ToDecimal(Convert.ToDecimal(hour.Split(':')[0]) + Convert.ToDecimal(TimeSpan.Parse("00:" + hour.Split(':')[1]).TotalHours));
        }
        public static TimeSpan DecimalParaHora(this decimal hour)
        {
            return TimeSpan.FromHours(Convert.ToDouble(hour));
        }

        public static string DecimalParaHoraString(this decimal hour)
        {
            return hour.DecimalParaHora().ToString("h\\:mm");
        }
    }
}
