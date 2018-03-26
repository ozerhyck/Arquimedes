using CommandLine;

namespace Arquimedes.MDL
{
    public class Options
    {
        [Option('l', "limite", Required = false, HelpText = "Informe o limite de horas nesse mes.")]
        public string Limite { get; set; }

        [Option('a', "atual", Required = false, HelpText = "Informe a quantidade de horas trabalhadas.")]
        public string Atual { get; set; }

        [Option('n', "agora", Required = false, HelpText = "Informe a quantidade de horas trabalhadas ate o exato momento.")]
        public string Agora { get; set; }

        [Option('d', "dias", Required = false, Default = false, HelpText = "Retorna aa quantidade de dias uteis do mês.")]
        public bool Dias { get; set; }

        [Option('h', "help", Required = false, Default = false, HelpText = "Acesso ´rapido ao Help")]
        public bool Help { get; set; }
    }
}
