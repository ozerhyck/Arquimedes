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

        public static string DecimalParaHora(this decimal hour)
        {
            var h = Convert.ToDouble(hour);
            var time = TimeSpan.FromHours(h).ToString("mm");

            return Convert.ToInt32(h.ToString().Split(',')[0]).ToString() + ":" + time;
        }
    }
}
