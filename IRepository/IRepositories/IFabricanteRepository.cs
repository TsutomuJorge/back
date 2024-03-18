using Entities.Entities;

namespace IRepository.IRepositories
{
    public interface IFabricanteRepository : IRepositoryBase<Fabricante>
    {
        Task<Fabricante?> ObterFabricantoPorNome(string nome);
    }
}
