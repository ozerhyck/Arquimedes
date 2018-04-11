using CommandLine;

namespace Arquimedes.MDL
{
    public class Options
    {
        [Option('l', "limite", Default = "", Required = false, HelpText = "Informe o limite de horas nesse mes.")]
        public string Limite { get; set; }

        [Option('a', "atual", Default = "", Required = false, HelpText = "Informe a quantidade de horas trabalhadas.")]
        public string Atual { get; set; }

        [Option('n', "agora", Default = "", Required = false, HelpText = "Informe a quantidade de horas trabalhadas ate o exato momento.")]
        public string Agora { get; set; }

        [Option('d', "dias", Required = false, Default = false, HelpText = "Retorna a quantidade de dias uteis do mês.")]
        public bool Dias { get; set; }

        [Option('t', "horaspordia", Required = false, Default = 0, HelpText = "Retorna a quantidade dehoras do mes, baseado nas horas por dia.")]
        public int HorasPorDia { get; set; }

    }
}
