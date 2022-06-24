using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class VeiculoRepository  : IVeiculoRepository
    {
    private readonly DataContext Context;

        public VeiculoRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task<IList<Veiculo>> GetAllAsync()
        {
            return await Context.DbSetVeiculo.ToListAsync();
        }

        public async Task<Veiculo> GetByIdAsync(int id)
        {
            return await Context.DbSetVeiculo
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Veiculo> GetByNomeAsync(string nome)
        {
            return await Context.DbSetVeiculo
                .AsNoTracking()
                //.Include(i => i.Roles)
                .FirstOrDefaultAsync(i => i.Nome == nome);
        }

        public void Save(Veiculo veiculo)
        {
            Context.DbSetVeiculo.Add(veiculo);
        }

        public void Update(Veiculo veiculo)
        {
            Context.Entry(veiculo).State = EntityState.Modified;
        }

        public bool Delete(int id)
        {
            var veiculo = Context.DbSetVeiculo.FirstOrDefault(i => i.Id == id);

            if (veiculo == null)
                return false;
            else
            {
                Context.DbSetVeiculo.Remove(veiculo);
                return true;
            }
        }
    }
}