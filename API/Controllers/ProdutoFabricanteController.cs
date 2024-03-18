using Entities.DTO;
using Entities.Entities;
using IBusiness.IBusiness;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoFabricanteController : ControllerBase
    {
        private readonly ILogger<ProdutoFabricanteController> _logger;
        private readonly IProdutoFabricanteBusiness _produtoFabricanteBusiness;

        public ProdutoFabricanteController(ILogger<ProdutoFabricanteController> logger, IProdutoFabricanteBusiness produtoFabricanteBusiness)
        {
            _logger = logger;
            _produtoFabricanteBusiness = produtoFabricanteBusiness;
        }

        [HttpGet(Name = "GetProdutoFabricante")]
        public async Task<List<ProdutoFabricanteDTO>> Get()
        {
            return await _produtoFabricanteBusiness.ConsultarProdutosFabricantes(true);
        }

        [HttpPost(Name = "AddProdutoFabricante")]
        public async Task<ProdutoFabricante> Post(ProdutoFabricanteDTO produtoFabricanteDTO)
        {
            var produtoFabricante = new ProdutoFabricante(produtoFabricanteDTO);
            return await _produtoFabricanteBusiness.Add(produtoFabricante);
        }

        [HttpPost("ImportarPlanilha")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ImportarPlanilha([FromForm] ArquivoImportadoDTO arquivoImportado)
        {
            await _produtoFabricanteBusiness.ImportarPlanilha(arquivoImportado);

            return Ok();
        }

        [HttpPut(Name = "UpdateProdutoFabricante")]
        public async Task<IActionResult> Put(ProdutoFabricanteDTO produtoFabricanteDTO)
        {
            await _produtoFabricanteBusiness.Update(produtoFabricanteDTO);

            return Ok();
        }

        [HttpPost("DeleteProdutoFabricante")]
        public async Task<IActionResult> Delete(ProdutoFabricanteDTO produtoFabricanteDTO)
        {
            var success = await _produtoFabricanteBusiness.Delete(produtoFabricanteDTO);

            if (success)
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
        }
    }
}
