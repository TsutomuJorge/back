using Entities.DTO;
using Utils.Extensions;

namespace Entities.Entities
{
    public class ProdutoFabricante : EntidadeBase
    {
        public ProdutoFabricante() { }

        public ProdutoFabricante(ProdutoFabricanteDTO dto)
        {
            Id = dto.Id;
            ValorUnitario = dto.ValorUnitario;
            CustoUnitario = dto.CustoUnitario;
            IdFabricante = dto?.IdFabricante ?? 0;
            IdProduto = dto?.IdProduto ?? 0 ;
            Fabricante = new Fabricante()
            {
                Id = dto?.IdFabricante ?? 0,
                Nome = dto.NomeFabricante.NormalizeSpacesAndCapitalize(),
            };
            Produto = new Produto()
            {
                Id = dto?.IdProduto ?? 0,
                Descricao = dto.DescricaoProduto.NormalizeSpacesAndCapitalize(),
            };
        }

        public ProdutoFabricante(ProdutoFabricanteDTO dto, Fabricante? fabricante, Produto? produto, ProdutoFabricante? produtoFabricante)
        {
            Id = produtoFabricante?.Id ?? dto.Id;
            IdFabricante = produtoFabricante?.IdFabricante ?? fabricante?.Id ?? 0;
            IdProduto = produtoFabricante?.IdProduto ?? produto?.Id ?? 0;
            ValorUnitario = dto.ValorUnitario;
            CustoUnitario = dto.CustoUnitario;
            AdicionarFabricante(fabricante, dto.NomeFabricante);
            AdicionarProduto(produto, dto.DescricaoProduto);
        }

        private void AdicionarProduto(Produto? produto, string descricaoProduto)
        {
            Produto = new Produto()
            {
                Id = produto?.Id ?? 0,
                Descricao = produto?.Descricao ?? descricaoProduto,
            };
        }

        private void AdicionarFabricante(Fabricante? fabricante, string NomeFabricante)
        {
            Fabricante = new Fabricante()
            {
                Id = fabricante?.Id ?? 0,
                Nome = fabricante?.Nome ?? NomeFabricante,
            };
        }

        public int IdFabricante { get; set; }
        public int IdProduto { get; set; }

        public decimal ValorUnitario { get; set; }
        public decimal CustoUnitario { get; set; }

        public Fabricante Fabricante { get; set; }
        public Produto Produto { get; set; }

    }
}
