using Entities.DTO;
using Entities.Entities;

namespace IBusiness.IBusiness
{
    public interface IProdutoFabricanteBusiness : IBaseBusiness<ProdutoFabricante>
    {
        Task<List<ProdutoFabricanteDTO>> ConsultarProdutosFabricantes(bool asNoTracking = false);
        Task ImportarPlanilha(ArquivoImportadoDTO arquivoImportado);
        Task<ProdutoFabricante> Update(ProdutoFabricanteDTO dto);
        Task<bool> Delete(ProdutoFabricanteDTO dto);
    }
}
