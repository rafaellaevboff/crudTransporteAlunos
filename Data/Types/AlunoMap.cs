using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("aluno");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .HasColumnName("userName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(i => i.Endereco)
                .HasColumnName("password")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();
            
            builder.Property(x => x.EscolaID)
                .HasColumnName("escolaId")
                .HasColumnType("Integer") //verificar integer ???
                .IsRequired();
                
            builder.HasOne(x => x.Escola)
                .WithMany(x => x.Alunos)
                .HasConstraintName("FK_Aluno_Escola")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}