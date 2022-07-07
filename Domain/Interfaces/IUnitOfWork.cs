using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
         Task CommitAsync();

        //adiciona as interfaces que usarão o UnitOfWork
         IEscolaRepository EscolaRepository{get;}
         IAlunoRepository AlunoRepository{get;}
         IMotoristaRepository MotoristaRepository{get;}
         IVeiculoRepository VeiculoRepository{get;}
         IResponsavelRepository ResponsavelRepository{get;}
         IServicoRepository ServicoRepository{get;}
    }
}