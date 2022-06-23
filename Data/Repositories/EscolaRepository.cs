using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EscolaRepository  : IEscolaRepository
    {
    private readonly DataContext Context;

        public EscolaRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task<IList<Escola>> GetAllAsync()
        {
            return await Context.DbSetEscola.ToListAsync();
        }

        public async Task<Escola> GetByIdAsync(int escolaId)
        {
            return await Context.DbSetEscola
                .FirstOrDefaultAsync(i => i.Id == escolaId);
        }

        public async Task<Escola> GetByNomeAsync(string nome)
        {
            return await Context.DbSetEscola
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Nome == nome);
        }

        public void Save(Escola escola)
        {
            Context.DbSetEscola.Add(escola);
        }

        public void Update(Escola escola)
        {
            Context.Entry(escola).State = EntityState.Modified;
        }

        public bool Delete(int escolaId)
        {
            var escola = Context.DbSetEscola.FirstOrDefault(i => i.Id == escolaId);

            if (escola == null)
                return false;
            else
            {
                Context.DbSetEscola.Remove(escola);
                return true;
            }
        }
    }
}