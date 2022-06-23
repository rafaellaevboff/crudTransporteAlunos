namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
         Task CommitAsync();

        //add as interfaces que usarão o UnitOfWork
         IMotoristaRepository MotoristaRepository{get;}
         IVeiculoRepository VeiculoRepository{get;}
    }
}