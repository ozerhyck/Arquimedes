using System;
using System.Configuration;
using Arquimedes.MDL;

namespace Arquimedes.BLL
{
    public static class Mes
    {
        private static readonly DateTime Agora = DateTime.Now;

        //Quantidade de dias
        public static int TotalDiasMes()
        {
            var primeiroDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var ultimoDiaDoMes = primeiroDia.AddMonths(1).AddDays(-1);

            var diasUteis = ultimoDiaDoMes.Day - TotalFeriados() - FimDeSemana(true);
            return diasUteis;
        }

        //Dias faltando
        public static int DiasFaltando(Options options)
        {
            var dferencialHoraBase = options.Agora != string.Empty ? 0 : -1;

            var hoje = DateTime.Now.Date.AddDays(dferencialHoraBase);
            var ultimoDiaDoMes = hoje.AddDays(-(hoje.Day - 1)).AddMonths(1).AddDays(-1);
            var primeiroDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var Feriados = Convert.ToInt32(ConfigurationManager.AppSettings["FeriadosMes"]);
            var diasFaltantes = ultimoDiaDoMes.AddDays(hoje.Day * -1).Day - FimDeSemana(false) - Feriados;

            return diasFaltantes;
        }

        //Quantidade de FDS
        public static int FimDeSemana(bool total)
        {
            var contador = 1;

            var PrimeiroDiadoMes = DateTime.Parse("01" + Agora.ToString("/ MM / yyyy"));
            var PrimeiroDiadoProximoMes = PrimeiroDiadoMes.AddMonths(1);
            var UltimoDiadoMes = PrimeiroDiadoProximoMes.AddDays(-1).Day;

            var dias = total ? PrimeiroDiadoMes.Day : Agora.Day;

            for (var i = dias; i < UltimoDiadoMes; i++)
            {
                var diaCorrido = DateTime.Parse(i.ToString() + Agora.ToString("/ MM / yyyy"));

                if (diaCorrido.DayOfWeek == DayOfWeek.Saturday)
                {
                    contador++;
                }
                else if (diaCorrido.DayOfWeek == DayOfWeek.Sunday)
                {
                    contador++;
                }
            }

            return contador - 1;
        }

        //Quantidade de feriados no Mes
        public static int TotalFeriados() => Convert.ToInt32(ConfigurationManager.AppSettings["FeriadosMes"]);

        //Quantidade de feriados faltando
        public static int TotalFeriadosFaltando() => 0;
    }
}
