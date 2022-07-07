using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly DataContext Context;

        public ServicoRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task<IList<Servico>> GetAllAsync()
        {
            return await Context.DbSetServico.ToListAsync();
        }

        public async Task<Servico> GetByIdAsync(int servicoId)
        {
            return await Context.DbSetServico
                .FirstOrDefaultAsync(i => i.Id == servicoId);
        }

        public void Save(Servico servico)
        {
            Context.DbSetServico.Add(servico);
        }

        public void Update(Servico servico)
        {
            Context.Entry(servico).State = EntityState.Modified;
        }

        public bool Delete(int servicoId)
        {
            var servico = Context.DbSetServico.FirstOrDefault(i => i.Id == servicoId);

            if (servico == null)
                return false;
            else
            {
                Context.DbSetServico.Remove(servico);
                return true;
            }
        }
    }
}