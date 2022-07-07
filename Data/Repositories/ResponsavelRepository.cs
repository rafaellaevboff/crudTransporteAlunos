using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ResponsavelRepository : IResponsavelRepository
    {
    private readonly DataContext Context;

        public ResponsavelRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task<IList<Responsavel>> GetAllAsync()
        {
            return await Context.DbSetResponsavel.ToListAsync();
        }

        public async Task<Responsavel> GetByIdAsync(int responsavelId)
        {
            return await Context.DbSetResponsavel
                .FirstOrDefaultAsync(i => i.Id == responsavelId);
        }

        public void Save(Responsavel responsavel)
        {
            Context.DbSetResponsavel.Add(responsavel);
        }

        public void Update(Responsavel responsavel)
        {
            Context.Entry(responsavel).State = EntityState.Modified;
        }

        public bool Delete(int responsavelId)
        {
            var responsavel = Context.DbSetResponsavel.FirstOrDefault(i => i.Id == responsavelId);

            if (responsavel == null)
                return false;
            else
            {
                Context.DbSetResponsavel.Remove(responsavel);
                return true;
            }
        }
    }
}