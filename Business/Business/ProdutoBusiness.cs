using Entities.Entities;
using IBusiness.IBusiness;
using IRepository.IRepositories;

namespace Business.Business
{
    public class ProdutoBusiness : BaseBusiness<Produto>, IProdutoBusiness
    {
        public readonly IProdutoRepository _produtoRepository;
        public ProdutoBusiness(IProdutoRepository produtoRepository) : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto?> ObterProdutoPorDescricao(string descricao)
        {
            return await _produtoRepository.ObterProdutoPorDescricao(descricao);
        }
    }
}
