using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
    private readonly DataContext Context;

        public AlunoRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task<IList<Aluno>> GetAllAsync()
        {
            return await Context.DbSetAluno.Include(x => x.Escola).Include(x => x.Motorista).ToListAsync();
        }

        public async Task<Aluno> GetByIdAsync(int alunoId)
        {
            return await Context.DbSetAluno
                .FirstOrDefaultAsync(i => i.Id == alunoId);
        }

        public void Save(Aluno aluno)
        {
            Context.DbSetAluno.Add(aluno);
        }

        public void Update(Aluno aluno)
        {
            Context.Entry(aluno).State = EntityState.Modified;
        }

        public bool Delete(int alunoId)
        {
            var aluno = Context.DbSetAluno.FirstOrDefault(i => i.Id == alunoId);

            if (aluno == null)
                return false;
            else
            {
                Context.DbSetAluno.Remove(aluno);
                return true;
            }
        }
    }
}