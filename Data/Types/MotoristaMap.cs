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
                .HasColumnType("Integer")
                .IsRequired();

            builder.HasOne(x => x.Veiculo)
                .WithMany(x => x.Motoristas)
                .HasConstraintName("FK_Motorista_Veiculo")
                .OnDelete(DeleteBehavior.Restrict);

            // builder
            //     .HasMany(i => i.Veiculos)
            //     .WithMany(i => i.Motoristas)
            //     .UsingEntity<Dictionary<string, object>>(
            //         "motorista_veiculo",
            //         veiculo => veiculo
            //             .HasOne<Veiculo>()
            //             .WithMany()
            //             .HasForeignKey("veiculo_id")
            //             .HasConstraintName("FK_motorista_veiculo_veiculo_id")
            //             .OnDelete(DeleteBehavior.Restrict),
            //         motorista => motorista
            //             .HasOne<Motorista>()
            //             .WithMany()
            //             .HasForeignKey("motorista_id")
            //             .HasConstraintName("FK_motorista_veiculo_motor_id")
            //             .OnDelete(DeleteBehavior.Cascade));

        }
    }
}