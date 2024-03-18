using Entities.Entities;

namespace IBusiness.IBusiness
{
    public interface IProdutoBusiness : IBaseBusiness<Produto>
    {
        Task<Produto?> ObterProdutoPorDescricao(string descricao);
    }
}
