using Entities.Entities;

namespace IRepository.IRepositories
{
    public interface IProdutoFabricanteRepository : IRepositoryBase<ProdutoFabricante>
    {
        Task<ProdutoFabricante?> ObterProdutoFabricantePorIdProdutoIdFabricante(int idProduto, int idFabricante);
    }
}
