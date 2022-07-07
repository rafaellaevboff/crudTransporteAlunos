using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class ResponsavelMap : IEntityTypeConfiguration<Responsavel>
    {
        public void Configure(EntityTypeBuilder<Responsavel> builder)
        {
            builder.ToTable("responsavel");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .HasColumnName("nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(i => i.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(i => i.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(18)
                .IsRequired();
        }
    }
}