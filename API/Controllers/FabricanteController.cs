using Entities.Entities;
using IBusiness.IBusiness;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FabricanteController : Controller
    {
        private readonly ILogger<FabricanteController> _logger;
        private readonly IFabricanteBusiness _fabricanteBusiness;

        public FabricanteController(ILogger<FabricanteController> logger, IFabricanteBusiness fabricanteBusiness)
        {
            _logger = logger;
            _fabricanteBusiness = fabricanteBusiness;
        }

        [HttpGet(Name = "GetFabricante")]
        public async Task<List<Fabricante>> Get()
        {
            return await _fabricanteBusiness.GetAll();
        }

        [HttpPost(Name = "AddFabricante")]
        public async Task<Fabricante> Post(Fabricante produto)
        {
            return await _fabricanteBusiness.Add(produto);
        }
    }
}
