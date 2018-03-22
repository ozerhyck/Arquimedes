using Arquimedes.MDL;
using System;

namespace Arquimedes.BLL
{
    public static class Time
    {
        public static string Response(Options options)
        {
            decimal HoraLimite = Core.HourToDecimal(Core.HourParse(options.Limite));
            decimal HoraConcluida = Core.HourToDecimal(Core.HourParse(options.Atual));
            decimal HoraFaltando = HoraLimite - HoraConcluida;

            var resultado = HoraFaltando / Core.daysToEndMonth();
            double teste = Convert.ToDouble(resultado);
            var resultadoHoras = TimeSpan.FromHours(teste).ToString("h\\:mm");

            return "Faltam " +
                    Core.DecimalToHour(HoraFaltando) +
                    "h.\nNos próximos " + Core.daysToEndMonth() + " dias, faça " + resultadoHoras + "h por dia.";
        }
        
    }
}
