using Domain.Entities;

namespace Domain.Interfaces
{
    public class IUserRepository : IBaseRepository<User>
    {
        public bool Delete(int idEntity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Save(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}