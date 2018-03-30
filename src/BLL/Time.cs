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
            var retorno = string.Empty;
            var diasParaFimdoMes = Core.daysToEndMonth(options);

            if (diasParaFimdoMes == 0)
            {
                //Fim do mes
                var resultado = HoraFaltando / 1;
                if (HoraFaltando < 0)
                {
                    retorno = "Voce ja passou " + TimeSpan.FromHours(Convert.ToDouble(resultado)).ToString("h\\:mm") + "h do seu limite.";
                }
                else
                {
                    retorno = "Faltam " + Core.DecimalToHour(HoraFaltando) +
                                  "h.\nHoje faça " + TimeSpan.FromHours(Convert.ToDouble(resultado)).ToString("h\\:mm") + "h.";
                }                
            }
            else if (diasParaFimdoMes > 0)
            {
                //Segue
                var resultado = HoraFaltando / Core.daysToEndMonth(options) <= 0 ? 1 : Core.daysToEndMonth(options);
                retorno = "Faltam " + Core.DecimalToHour(HoraFaltando) +
                        "h.\nNos próximos " + Core.daysToEndMonth(options) + " dias, faça " + TimeSpan.FromHours(Convert.ToDouble(resultado)).ToString("h\\:mm") + "h por dia.";
            }

            return retorno;

        }

        public static string DiasUteis()
        {
            return $"Este mes tem {Core.UsualDays()} dias uteis." ;
        }
        
    }
}
