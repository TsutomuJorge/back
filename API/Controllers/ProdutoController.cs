using Entities.Entities;
using IBusiness.IBusiness;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoBusiness _produtoBusiness;

            public ProdutoController(ILogger<ProdutoController> logger, IProdutoBusiness produtoBusiness)
        {
            _logger = logger;
            _produtoBusiness = produtoBusiness;
        }

        [HttpGet(Name = "GetProduto")]
        public async Task<List<Produto>> Get()
        {
            return await _produtoBusiness.GetAll();
        }

        [HttpPost(Name = "AddProduto")]
        public async Task<Produto> Post(Produto produto)
        {
            return await _produtoBusiness.Add(produto);
        }
    }
}