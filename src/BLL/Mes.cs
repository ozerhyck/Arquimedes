using Arquimedes.MDL;
using System;
using System.Configuration;

namespace Arquimedes.BLL
{
    public static class Mes
    {
        static DateTime data = DateTime.Now;

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
            var dferencialHoraBase = ((options.Agora != null) ? 0 : -1);
            dferencialHoraBase = ((options.Agora != string.Empty) ? 0 : -1);

            var hoje = DateTime.Now.Date.AddDays(dferencialHoraBase);
            var ultimoDiaDoMes = hoje.AddDays(-(hoje.Day - 1)).AddMonths(1).AddDays(-1);
            var primeiroDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var Feriados = Convert.ToInt32(ConfigurationManager.AppSettings["FeriadosMes"]);
            var diasFaltantes = ultimoDiaDoMes.AddDays(hoje.Day * -1).Day - FimDeSemana(false) - Feriados;

            //if (options.Agora != string.Empty) diasFaltantes += 1;

            return diasFaltantes;
        }      

        //Quantidade de FDS
        public static int FimDeSemana(bool Total)
        {
            int contador = 1;

            DateTime PrimeiroDiadoMes = DateTime.Parse("01" + data.ToString("/ MM / yyyy"));
            DateTime PrimeiroDiadoProximoMes = PrimeiroDiadoMes.AddMonths(1);
            var UltimoDiadoMes = PrimeiroDiadoProximoMes.AddDays(-1).Day;

            int dias = (Total ? PrimeiroDiadoMes.Day : data.Day);

            for (int i = dias; i < UltimoDiadoMes; i++)
            {
                DateTime diaCorrido = DateTime.Parse(i.ToString() + data.ToString("/ MM / yyyy"));

                if (diaCorrido.DayOfWeek == DayOfWeek.Saturday)
                    contador++;
                else if (diaCorrido.DayOfWeek == DayOfWeek.Sunday)
                    contador++;
            }

            return contador -1;
        }

        //Quantidade de feriados no Mes
        public static int TotalFeriados()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings["FeriadosMes"]);
        }

        //Quantidade de feriados faltando
        public static int TotalFeriadosFaltando()
        {
            return 0;
        }
    }
}
