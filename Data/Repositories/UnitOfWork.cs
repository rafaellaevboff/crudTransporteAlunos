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

        private IEscolaRepository _EscolaRepository;
        public IEscolaRepository EscolaRepository
        {
            get { return _EscolaRepository ??= new EscolaRepository(_Context); }
        }

        private IAlunoRepository _AlunoRepository;
        public IAlunoRepository AlunoRepository
        {
            get { return _AlunoRepository ??= new AlunoRepository(_Context); }
        }
    }
}