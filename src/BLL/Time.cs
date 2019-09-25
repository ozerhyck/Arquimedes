using System;
using Arquimedes.MDL;

namespace Arquimedes.BLL
{
    public static class Time
    {
        public static string Response(Options options)
        {
            var horaLimite = options.Limite.HoraParaDecimal();
            var horaConcluida = (options.Atual != string.Empty ? options.Atual.HoraParaDecimal() : options.Agora.HoraParaDecimal());
            var horaFaltando = horaLimite - horaConcluida;
            var retorno = string.Empty;
            var diasParaFimdoMes = Mes.DiasFaltando(options);

            if (diasParaFimdoMes <= 0)
            {
                //Fim do mes
                var resultado = horaFaltando / 1;

                if (horaFaltando < 0)
                {
                    retorno = "Voce ja passou " + TimeSpan.FromHours(Convert.ToDouble(resultado)).ToString("h\\:mm") + "h do seu limite.";
                }
                else
                {
                    retorno = "Faltam " + horaFaltando.DecimalParaHora() +
                                  "h.\nHoje faça " + TimeSpan.FromHours(Convert.ToDouble(resultado)).ToString("h\\:mm") + "h.";
                }
            }
            else if (diasParaFimdoMes > 0)
            {
                //Segue
                var resultado = Math.Round(horaFaltando / Mes.DiasFaltando(options), 4, MidpointRounding.ToEven);


                var teste = TimeSpan.FromMinutes(Convert.ToDouble(resultado));
                var teste2 = teste.TotalMinutes;
                var minutesconv = teste2 * Mes.DiasFaltando(options);
                var converted = TimeSpan.FromHours(minutesconv);



                retorno = "Faltam " + horaFaltando.DecimalParaHora() +
                          "h.\nNos próximos " + Mes.DiasFaltando(options) +
                          " dias, faça " + TimeSpan.FromHours(Convert.ToDouble(resultado)).ToString("h\\:mm") + "h por dia. Isso da um total de " + converted.ToString("h\\:mm") + "h no fim.";
            }

            return retorno;

        }

        public static string DiasUteis() => $"Este mes tem {Mes.TotalDiasMes()} dias uteis.";

        public static string HorasMes(Options options)
        {
            var hpordia = options.HorasPorDia.ToString().FormataHora();
            var hpordiadecimal = options.HorasPorDia.ToString().HoraParaDecimal();
            return $"Para {hpordia} horas por dia, neste mes deve se limitar a {(Mes.DiasFaltando(options) * hpordiadecimal)} horas";
        }
    }
}
