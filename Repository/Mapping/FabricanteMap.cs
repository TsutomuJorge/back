using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mapping
{
    public class FabricanteMap : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.ToTable("tb_fabricante");

            builder.HasKey(e => new { e.Id });

            builder.Property(e => e.Id)
                .HasColumnName("id_fabricante")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("nome")
                .IsRequired();
        }
    }
}
