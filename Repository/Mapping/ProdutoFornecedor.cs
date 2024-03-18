using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mapping
{
    public class ProdutoFabricanteMap : IEntityTypeConfiguration<ProdutoFabricante>
    {
        public void Configure(EntityTypeBuilder<ProdutoFabricante> builder)
        {
            builder.ToTable("tb_produto_fabricante");

            builder.HasKey(e => new { e.Id });

            builder.Property(e => e.Id)
                .HasColumnName("id_produto_fabricante")
                .IsRequired();

            builder.Property(e => e.ValorUnitario)
                .HasColumnName("valor_unitario")
                .IsRequired();

            builder.Property(e => e.CustoUnitario)
                .HasColumnName("custo_unitario")
                .IsRequired();

            builder.Property(e => e.IdProduto)
                .HasColumnName("id_produto")
                .IsRequired();

            builder.Property(e => e.IdFabricante)
                .HasColumnName("id_fabricante")
                .IsRequired();

            builder.HasOne(e => e.Produto)
                .WithMany()
                .HasForeignKey(e => e.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Fabricante)
                .WithMany()
                .HasForeignKey(e => e.IdFabricante)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
