using Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTO
{
    public class ArquivoImportadoDTO
    {
        public ArquivoImportadoDTO()
        {

        }

        public ArquivoImportadoDTO(ArquivoImportado arquivoImportado)
        {
            Arquivo = arquivoImportado.Arquivo;
        }

        public IFormFile Arquivo { get; set; }
    }
}
