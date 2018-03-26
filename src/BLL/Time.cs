using Arquimedes.MDL;
using System;

namespace Arquimedes.BLL
{
    public static class Time
    {
        public static string Response(Options options)
        {
            decimal HoraLimite = Core.HourToDecimal(Core.HourParse(options.Limite));
            decimal HoraConcluida = Core.HourToDecimal(Core.HourParse(options.Atual != null? options.Atual: options.Agora ));
            decimal HoraFaltando = HoraLimite - HoraConcluida;

            var resultado = HoraFaltando / Core.daysToEndMonth(options);
            double teste = Convert.ToDouble(resultado);
            var resultadoHoras = TimeSpan.FromHours(teste).ToString("h\\:mm");

            return "Faltam " + Core.DecimalToHour(HoraFaltando) +
                    "h.\nNos próximos " + Core.daysToEndMonth(options) + " dias, faça " + resultadoHoras + "h por dia.";
        }

        public static string DiasUteis()
        {
            return $"Este mes tem {Core.UsualDays()} dias uteis." ;
        }
        
    }
}
