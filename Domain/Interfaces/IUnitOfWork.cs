namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
         Task CommitAsync();

        //add as interfaces que usarão o UnitOfWork
         IServicoRepository ServicoRepository{get;}
         IResponsavelRepository ResponsavelRepository{get;}
    }
}