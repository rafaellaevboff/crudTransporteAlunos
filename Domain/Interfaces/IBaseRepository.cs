namespace Domain.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
         Task<Entity> GetByIdAsync(int entityId);
         Task<IList<Entity>> GetAllAsync();
         void Save(Entity entity);
         bool Delete(int idEntity);
         void Update(Entity entity);
    }
}