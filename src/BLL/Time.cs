using Arquimedes.MDL;
using Arquimedes.BLL;
using System;

namespace Arquimedes.BLL
{
    public static class Time
    {
        public static string Response(Options options)
        {
            decimal HoraLimite = options.Limite.HoraParaDecimal();
            decimal HoraConcluida = (options.Atual != string.Empty ? options.Atual.HoraParaDecimal() : options.Agora.HoraParaDecimal());
            decimal HoraFaltando = HoraLimite - HoraConcluida;
            var retorno = string.Empty;
            var diasParaFimdoMes = Mes.DiasFaltando(options);

            if (diasParaFimdoMes <= 0)
            {
                //Fim do mes
                var resultado = HoraFaltando / 1;

                if (HoraFaltando < 0)
                {
                    retorno = "Voce ja passou " + TimeSpan.FromHours(Convert.ToDouble(resultado)).ToString("h\\:mm") + "h do seu limite.";
                }
                else
                {
                    retorno = "Faltam " + HoraFaltando.DecimalParaHora() +
                                  "h.\nHoje faça " + TimeSpan.FromHours(Convert.ToDouble(resultado)).ToString("h\\:mm") + "h.";
                }                
            }
            else if (diasParaFimdoMes > 0)
            {
                //Segue
                var resultado = HoraFaltando / Mes.DiasFaltando(options); 

                retorno = "Faltam " + HoraFaltando.DecimalParaHora() +
                          "h.\nNos próximos " + Mes.DiasFaltando(options)  + 
                          " dias, faça " + TimeSpan.FromHours(Convert.ToDouble(resultado)).ToString("h\\:mm") + "h por dia.";
            }

            return retorno;

        }

        public static string DiasUteis()
        {
            return $"Este mes tem {Mes.TotalDiasMes()} dias uteis." ;
        }

        public static string HorasMes(Options options)
        {
            var hpordia = options.HorasPorDia.ToString().FormataHora();
            var hpordiadecimal = options.HorasPorDia.ToString().HoraParaDecimal();
            return $"Para {hpordia} horas por dia, neste mes deve se limitar a {(Mes.DiasFaltando(options) * hpordiadecimal)} horas";
        }  
    }
}
