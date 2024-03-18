using Entities.Entities;
using IRepository.IRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories
{
    public class ProdutoFabricanteRepository : RepositoryBase<ProdutoFabricante>, IProdutoFabricanteRepository
    {
        public ProdutoFabricanteRepository(EstabelecimentoContext context) : base(context)
        {
        }

        public override Task<List<ProdutoFabricante>> All(bool asNoTracking = false)
        {
            return EntitySet.Include(x => x.Produto).Include(x => x.Fabricante).ToListAsync();
        }

        public Task<ProdutoFabricante?> ObterProdutoFabricantePorIdProdutoIdFabricante(int idProduto, int idFabricante)
        {
            return EntitySet.AsNoTracking().FirstOrDefaultAsync(x => x.IdProduto == idProduto && x.IdFabricante == idFabricante);
        }
    }
}
