using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tb_produto");

            builder.HasKey(e => new { e.Id });

            builder.Property(e => e.Id)
                .HasColumnName("id_produto")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnName("descricao")
                .IsRequired();
        }
    }
}
