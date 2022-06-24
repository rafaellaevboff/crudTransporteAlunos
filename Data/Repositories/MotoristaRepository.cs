using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class MotoristaRepository  : IMotoristaRepository
    {
    private readonly DataContext Context;

        public MotoristaRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task<IList<Motorista>> GetAllAsync()
        {
            return await Context.DbSetMotorista.ToListAsync();
        }

        public async Task<Motorista> GetByIdAsync(int id)
        {
            return await Context.DbSetMotorista
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public void Save(Motorista motorista)
        {
            Context.DbSetMotorista.Add(motorista);
        }

        public void Update(Motorista motorista)
        {
            Context.Entry(motorista).State = EntityState.Modified;
        }

        public bool Delete(int id)
        {
            var motorista = Context.DbSetMotorista.FirstOrDefault(i => i.Id == id);

            if (motorista == null)
                return false;
            else
            {
                Context.DbSetMotorista.Remove(motorista);
                return true;
            }
        }
    }
}