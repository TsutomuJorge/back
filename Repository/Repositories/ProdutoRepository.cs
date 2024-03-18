using Entities.Entities;
using IRepository.IRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Utils.Extensions;

namespace Repository.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(EstabelecimentoContext context) : base(context)
        {
        }

        public Task<Produto?> ObterProdutoPorDescricao(string descricao)
        {
            return EntitySet.AsNoTracking().FirstOrDefaultAsync(x => x.Descricao == descricao.NormalizeSpacesAndCapitalize());
        }
    }
}
