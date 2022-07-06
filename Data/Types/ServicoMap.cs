using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("servico");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(x => x.AlunoID)
                .HasColumnName("alunoId")
                .HasColumnType("INTEGER")
                .IsRequired();
                
            builder.HasOne(x => x.Aluno)
                .WithOne(x => x.Servico)
                .HasConstraintName("FK_Aluno_Servico")
                .HasForeignKey<Servico>(i => i.AlunoID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}