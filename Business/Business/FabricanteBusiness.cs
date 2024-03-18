using Entities.Entities;
using IBusiness.IBusiness;
using IRepository.IRepositories;

namespace Business.Business
{
    public class FabricanteBusiness : BaseBusiness<Fabricante>, IFabricanteBusiness
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        public FabricanteBusiness(IFabricanteRepository repository) : base(repository)
        {
            _fabricanteRepository = repository;
        }

        public async Task<Fabricante?> ObterFabricantoPorNome(string nome)
        {
            return await _fabricanteRepository.ObterFabricantoPorNome(nome);
        }
    }
}
