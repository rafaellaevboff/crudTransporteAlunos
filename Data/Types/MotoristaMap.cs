using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class MotoristaMap : IEntityTypeConfiguration<Motorista>
    {
        public void Configure(EntityTypeBuilder<Motorista> builder)
        {
            builder.ToTable("motorista");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .HasColumnName("nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(i => i.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(i => i.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(18)
                .IsRequired();

            builder.Property(i => i.Email)
                .HasColumnName("email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(155)
                .IsRequired();

            builder.Property(x => x.VeiculoID)
                .HasColumnName("veiculoId")
                .HasColumnType("Integer") //verificar integer ???
                .IsRequired();
                
            builder.HasOne(x => x.Veiculo)
                .WithMany(x => x.Motoristas)
                .HasConstraintName("FK_Motorista_Veiculo")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}