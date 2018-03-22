using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquimedes.MDL
{
    public class Options
    {
        [Option('l', "limite", Required = true, HelpText = "Informe o limite de horas nesse mes.")]
        public string Limite { get; set; }

        [Option('a', "atual", Required = true, HelpText = "Informe a quantidade de horas trabalhadas.")]
        public string Atual { get; set; }

        [Option('h', "help", Required = false, Default = false, HelpText = "Acesso ´rapido ao Help")]
        public bool Help { get; set; }
    }
}
