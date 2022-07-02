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
        
        private IResponsavelRepository _ResponsavelRepository;
        public IResponsavelRepository ResponsavelRepository
        {
            get { return _ResponsavelRepository ??= new ResponsavelRepository(_Context); }
        }
        
        private IServicoRepository _ServicoRepository;
        public IServicoRepository ServicoRepository
        {
            get { return _ServicoRepository ??= new ServicoRepository(_Context); }
        }

    }
}