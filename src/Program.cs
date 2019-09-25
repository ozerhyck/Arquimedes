using System;
using Arquimedes.BLL;
using Arquimedes.MDL;
using CommandLine;

namespace Arquimedes
{
    internal static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var parser = new Parser(bla => bla.HelpWriter = Console.Out);
            var result = parser.ParseArguments<Options>(args);
            var options = result.MapResult(o => o, o => null);

            try
            {
                if (options.Dias)
                {
                    Console.WriteLine(Time.DiasUteis());
                    return;
                }

                if (options.HorasPorDia > 0)
                {
                    Console.WriteLine(Time.HorasMes(options));
                    return;
                }

                Console.WriteLine(Time.Response(options));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}


