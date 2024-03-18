using Entities.Entities;
using IRepository.IRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Utils.Extensions;

namespace Repository.Repositories
{
    public class FabricanteRepository : RepositoryBase<Fabricante>, IFabricanteRepository
    {
        public FabricanteRepository(EstabelecimentoContext context) : base(context)
        {
        }

        public Task<Fabricante?> ObterFabricantoPorNome(string nome)
        {
            return EntitySet.AsNoTracking().FirstOrDefaultAsync(x => x.Nome == nome.NormalizeSpacesAndCapitalize());
        }
    }
}
