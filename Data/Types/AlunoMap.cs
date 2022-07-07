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
                .HasColumnName("nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(i => i.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();
            
            // CHAVES ESTRANGEIRAS

            builder.Property(x => x.EscolaID)
                .HasColumnName("escolaId")
                .HasColumnType("INTEGER")
                .IsRequired();
                
            builder.HasOne(x => x.Escola)
                .WithMany(x => x.Alunos)
                .HasConstraintName("FK_Aluno_Escola")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.MotoristaID)
                .HasColumnName("motoristaId")
                .HasColumnType("INTEGER")
                .IsRequired();
                
            builder.HasOne(x => x.Motorista)
                .WithMany(x => x.Alunos)
                .HasConstraintName("FK_Aluno_Motorista")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.ResponsavelID)
                .HasColumnName("responsavelId")
                .HasColumnType("INTEGER")
                .IsRequired();
                
            builder.HasOne(x => x.Responsavel)
                .WithMany(x => x.Alunos)
                .HasConstraintName("FK_Aluno_Responsavel")
                .OnDelete(DeleteBehavior.Restrict);

            // conexão com servico esta em ServicoMap
        }
    }
}