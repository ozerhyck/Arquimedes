using Arquimedes.MDL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var diasUteis = 1 + ultimoDiaDoMes.Day - TotalFeriados() - FimDeSemana(true);
            return diasUteis;
        }

        //Dias faltando
        public static int DiasFaltando(Options options)
        {
            var dferencialHoraBase = (options.Agora != null ? 2 : 1);

            var hoje = DateTime.Now.Date.AddDays(-1);
            var ultimoDiaDoMes = hoje.AddDays(-(hoje.Day - 1)).AddMonths(1).AddDays(-dferencialHoraBase);
            var primeiroDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var Feriados = Convert.ToInt32(ConfigurationManager.AppSettings["FeriadosMes"]);
            var diasFaltantes = ultimoDiaDoMes.AddDays(hoje.Day * -1).Day - FimDeSemana(false) - Feriados;

            if (options.Agora != string.Empty) diasFaltantes -= 1;

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

            return contador;
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
