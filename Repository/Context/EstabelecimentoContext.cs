using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class EstabelecimentoContext : DbContext
    {
        public EstabelecimentoContext(DbContextOptions<EstabelecimentoContext> options): base(options)
        {
        }

        public DbSet<Fabricante> Produtos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<ProdutoFabricante> ProdutoFabricantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstabelecimentoContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
