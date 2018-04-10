using Arquimedes.MDL;
using Arquimedes.BLL;
using CommandLine;
using CommandLine.Text;
using System;

namespace Arquimedes
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var parser = new Parser(bla => bla.HelpWriter = Console.Out);
            var result = parser.ParseArguments<Options>(args);
            var options = result.MapResult(o => o, o => null);

            try
            {

                if (options.Dias )
                {
                    Console.WriteLine(Time.DiasUteis());
                    return;
                }

                if (options.HorasPorDia > 0)
                {
                    Console.WriteLine(Time.HorasMes(options.HorasPorDia));
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


