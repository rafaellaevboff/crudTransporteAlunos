using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEscolaRepository : IBaseRepository<Escola>
    {
        Task<Escola> GetByNomeAsync(string entityNome);
    }
}