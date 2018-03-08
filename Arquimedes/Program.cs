using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arquimedes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Options config = Parse(args);

            try
            {
                Console.WriteLine("___________________________________________________________________");
                Console.WriteLine(@"---    ___                     _                    __          ---");
                Console.WriteLine(@"---   /   |  _________ ___  __(_)___ ___  ___  ____/ /__  _____ ---");
                Console.WriteLine(@"---  / /| | / ___/ __ `/ / / / / __ `__ \/ _ \/ __  / _ \/ ___/ ---");
                Console.WriteLine(@"--- / ___ |/ /  / /_/ / /_/ / / / / / / /  __/ /_/ /  __(__  )  ---");
                Console.WriteLine(@"---/_/  |_/_/   \__, /\__,_/_/_/ /_/ /_/\___/\__,_/\___/____/   ---");
                Console.WriteLine(@"---               /_/                                           ---");
                Console.WriteLine("___________________________________________________________________");
















                decimal HoraLimite = HourToDecimal(HourParse(config.Limite));
                decimal HoraConcluida = HourToDecimal(HourParse(config.Atual)); 
                decimal HoraFaltando = HoraLimite - HoraConcluida;
                                
                var resultado = HoraFaltando / daysToEndMonth();
                double teste = Convert.ToDouble(resultado);
                var resultadoHoras = TimeSpan.FromHours(teste).ToString("h\\:mm");

                Console.WriteLine("Faltam " + DecimalToHour(HoraFaltando) + "h.\nNos próximos " + daysToEndMonth() + " dias, faça " + resultadoHoras + "h por dia.");

                Console.ReadKey();
                Console.Clear();

            }
            catch (Exception)
            {
                Console.WriteLine("Pare de agir como bobo.");
            }

        }

         
        private static int daysToEndMonth()
        {
            var hoje = DateTime.Now.Date.AddDays(-1);
            var ultimoDiaDoMes = hoje.AddDays(-(hoje.Day - 1)).AddMonths(1).AddDays(-1);
            var primeiroDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var diasFaltantes = ultimoDiaDoMes.AddDays(hoje.Day * -1).Day - FinsDeSemana();

            return diasFaltantes;
        }

        private static string HourParse(string hour)
        {            
            if (!hour.Contains(':'))
            {
                hour = hour + ":00";
            }
            return hour;
        }

        private static decimal HourToDecimal(string hour)
        {            
            return Convert.ToDecimal(Convert.ToDecimal(hour.Split(':')[0]) + Convert.ToDecimal(TimeSpan.Parse("00:" + hour.Split(':')[1]).TotalHours)); 
        }

        private static string DecimalToHour(decimal hour)
        {
            var h = Convert.ToDouble(hour);
            var time = TimeSpan.FromHours(h).ToString("mm");

            return Convert.ToInt32(h.ToString().Split(',')[0]).ToString() + ":" + time;
        }

        private static int FinsDeSemana()
        {
            var _data = DateTime.Now;
            int contador = 1;

            DateTime PrimeiroDiadoMes = DateTime.Parse("01" + _data.ToString("/ MM / yyyy"));
            DateTime PrimeiroDiadoProximoMes = PrimeiroDiadoMes.AddMonths(1);
            var UltimoDiadoMes = PrimeiroDiadoProximoMes.AddDays(-1).Day;

            for (int i = _data.Day; i < UltimoDiadoMes; i++)
            {
                DateTime diaCorrido = DateTime.Parse(i.ToString() + _data.ToString("/ MM / yyyy"));

                if (diaCorrido.DayOfWeek == DayOfWeek.Saturday)
                    contador++;
                else if (diaCorrido.DayOfWeek == DayOfWeek.Sunday)
                    contador++;
            }

            return contador;
        }

        internal static Options Parse(string[] args)
        {
            var parser = new Parser(bla => bla.HelpWriter = Console.Out);
            var result = parser.ParseArguments<Options>(args);
            var config = result.MapResult(o => o, o => null);

            return config;
        }

    }
    public class Options
    {
        [Option('l', "limite", Required = true, HelpText = "Informe o limite de horas nesse mes.")]
        public string Limite { get; set; }

        [Option('a', "atual", Required = true, HelpText = "Informe a quantidade de horas trabalhadas.")]
        public string Atual { get; set; }
    }
}
