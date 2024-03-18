using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace API.Configurations
{
    public static class ConfigServices
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            string mySqlConnection =
                            configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            services.AddDbContextPool<EstabelecimentoContext>(options =>    
                options.UseMySql(mySqlConnection,
                      ServerVersion.AutoDetect(mySqlConnection)));
        }
    }
}
