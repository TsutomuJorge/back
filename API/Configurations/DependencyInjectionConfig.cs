using Business.Business;
using IBusiness.IBusiness;
using IRepository.IRepositories;
using Repository.Repositories;

namespace API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFabricanteBusiness, FabricanteBusiness>();
            services.AddScoped<IProdutoBusiness, ProdutoBusiness>();
            services.AddScoped<IProdutoFabricanteBusiness, ProdutoFabricanteBusiness>();

            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoFabricanteRepository, ProdutoFabricanteRepository>();
        }
    }
}
