using Data.Context;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _Context;

        public UnitOfWork(DataContext context)
        {
            this._Context = context;
        }

        public async Task CommitAsync()
        {
            await _Context.SaveChangesAsync();
        }
        
        private IMotoristaRepository _MotoristaRepository;
        public IMotoristaRepository MotoristaRepository
        {
            get { return _MotoristaRepository ??= new MotoristaRepository(_Context); }
        }

        private IVeiculoRepository _VeiculoRepository;
        public IVeiculoRepository VeiculoRepository
        {
            get { return _VeiculoRepository ??= new VeiculoRepository(_Context); }
        }

    }
}