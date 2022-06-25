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
                
        //     builder
        //         .HasMany(i => i.Veiculo)
        //         .WithMany(i => i.Motorista)
        //         .UsingEntity<Dictionary<string, object>>(
        //             "motorista_veiculo",
        //             veiculo => veiculo
        //                 .HasOne<Veiculo>()
        //                 .WithMany()
        //                 .HasForeignKey("veiculo_id")
        //                 .HasConstraintName("FK_motorista_veiculo_veiculo_id")
        //                 .OnDelete(DeleteBehavior.Cascade),
        //             motorista => motorista
        //                 .HasOne<User>()
        //                 .WithMany()
        //                 .HasForeignKey("motorista_id")
        //                 .HasConstraintName("FK_motorista_veiculo_motorista_id")
        //                 .OnDelete(DeleteBehavior.Cascade));
        }
    }
}