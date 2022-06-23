namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
         Task CommitAsync();

        //add as interfaces que usarão o UnitOfWork
         IEscolaRepository EscolaRepository{get;}
         IAlunoRepository AlunoRepository{get;}
    }
}