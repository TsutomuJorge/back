using Entities.DTO;
using Microsoft.AspNetCore.Http;

namespace Entities.Entities
{
    public class ArquivoImportado
    {
        public ArquivoImportado(ArquivoImportadoDTO dto)
        {
            Arquivo = dto.Arquivo;
        }

        public IFormFile Arquivo { get; set; }
    }
}
