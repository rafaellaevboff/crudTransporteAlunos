using Data.Types;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}
        
        public DbSet<Escola> DbSetEscola {get; set;}
        public DbSet<Aluno> DbSetAluno {get; set;}
        public DbSet<Motorista> DbSetMotorista {get; set;}
        public DbSet<Veiculo> DbSetVeiculo {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EscolaMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new MotoristaMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
        }
    }
}