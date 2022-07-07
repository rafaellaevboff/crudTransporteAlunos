using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("veiculo");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .HasColumnName("nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(i => i.Placa)
                .HasColumnName("placa")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(i => i.Ano)
                .HasColumnName("ano")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(i => i.Cor)
                .HasColumnName("cor")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}