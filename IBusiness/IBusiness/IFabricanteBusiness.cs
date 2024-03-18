using Entities.Entities;

namespace IBusiness.IBusiness
{
    public interface IFabricanteBusiness : IBaseBusiness<Fabricante>
    {
        Task<Fabricante?> ObterFabricantoPorNome(string nome);
    }
}
