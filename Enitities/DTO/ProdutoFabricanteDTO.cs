using Entities.Constants;
using Entities.Entities;
using Entities.Enums;
using Entities.ModelsFile;

namespace Entities.DTO
{
    public class ProdutoFabricanteDTO
    {
        public ProdutoFabricanteDTO()
        {

        }

        public ProdutoFabricanteDTO(string descricaoProduto,
            string nomeFabricante,
            decimal valorUnitario,
            decimal valorMinimo,
            decimal custoUnitario)
        {
            DescricaoProduto = descricaoProduto;
            NomeFabricante = nomeFabricante;
            ValorUnitario = valorUnitario;
            CustoUnitario = custoUnitario;
        }

        public ProdutoFabricanteDTO(ProdutoFabricante entitie)
        {
            Id = entitie.Id;
            ValorUnitario = entitie.ValorUnitario;
            CustoUnitario = entitie.CustoUnitario;
            IdFabricante = entitie.Fabricante.Id;
            NomeFabricante = entitie.Fabricante.Nome;
            IdProduto = entitie.Produto.Id;
            DescricaoProduto = entitie.Produto.Descricao;
        }

        [PlanilhaOpcoes(Nome = "Id", Coluna = OrdemColunas.PRIMEIRA_COLUNA, Tipo = PlanilhaOpcoesTipo.Texto, Alinhamento = PlanilhaOpcoesAlinhamento.Esquerda)]
        public int Id { get; set; }

        [PlanilhaOpcoes(Nome = "ValorUnitario", Coluna = OrdemColunas.PRIMEIRA_COLUNA, Tipo = PlanilhaOpcoesTipo.Texto, Alinhamento = PlanilhaOpcoesAlinhamento.Esquerda)]
        public decimal ValorUnitario { get; set; }

        [PlanilhaOpcoes(Nome = "CustoUnitario", Coluna = OrdemColunas.PRIMEIRA_COLUNA, Tipo = PlanilhaOpcoesTipo.Texto, Alinhamento = PlanilhaOpcoesAlinhamento.Esquerda)]
        public decimal CustoUnitario { get; set; }

        [PlanilhaOpcoes(Nome = "IdFabricante", Coluna = OrdemColunas.PRIMEIRA_COLUNA, Tipo = PlanilhaOpcoesTipo.Texto, Alinhamento = PlanilhaOpcoesAlinhamento.Esquerda)]
        public int? IdFabricante { get; set; }

        [PlanilhaOpcoes(Nome = "NomeFabricante", Coluna = OrdemColunas.PRIMEIRA_COLUNA, Tipo = PlanilhaOpcoesTipo.Texto, Alinhamento = PlanilhaOpcoesAlinhamento.Esquerda)]
        public string NomeFabricante { get; set; }

        [PlanilhaOpcoes(Nome = "IdProduto", Coluna = OrdemColunas.PRIMEIRA_COLUNA, Tipo = PlanilhaOpcoesTipo.Texto, Alinhamento = PlanilhaOpcoesAlinhamento.Esquerda)]
        public int? IdProduto { get; set; }

        [PlanilhaOpcoes(Nome = "DescricaoProduto", Coluna = OrdemColunas.PRIMEIRA_COLUNA, Tipo = PlanilhaOpcoesTipo.Texto, Alinhamento = PlanilhaOpcoesAlinhamento.Esquerda)]
        public string DescricaoProduto { get; set; }
    }
}
