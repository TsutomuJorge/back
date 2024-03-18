using Entities.Enums;

namespace Entities.ModelsFile
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class PlanilhaOpcoesAttribute : Attribute
    {
        public PlanilhaOpcoesAttribute(string nome, int coluna, PlanilhaOpcoesAlinhamento alinhamento, PlanilhaOpcoesTipo tipo, int tamanhoColuna, string corColuna)
        {
            Nome = nome;
            Coluna = coluna;
            Alinhamento = alinhamento;
            Tipo = tipo;
            TamanhoColuna = tamanhoColuna;
            CorColuna = corColuna;
        }

        public PlanilhaOpcoesAttribute()
        {
        }

        public string Nome { get; set; }
        public int Coluna { get; set; }
        public PlanilhaOpcoesAlinhamento Alinhamento { get; set; }
        public PlanilhaOpcoesTipo Tipo { get; set; }
        public int TamanhoColuna { get; set; }
        public string CorColuna { get; set; }
    }
}
