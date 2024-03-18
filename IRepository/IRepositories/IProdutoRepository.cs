using Entities.Entities;

namespace IRepository.IRepositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<Produto?> ObterProdutoPorDescricao(string descricao);
    }
}
