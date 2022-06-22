using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository  : IUserRepository
    {
    private readonly DataContext Context;

        public UserRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await Context.DbSetUser.ToListAsync();
        }

        public async Task<User> GetByIdAsync(long userId)
        {
            return await Context.DbSetUser
                .FirstOrDefaultAsync(i => i.Id == userId);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await Context.DbSetUser
                .AsNoTracking()
                //.Include(i => i.Roles)
                .FirstOrDefaultAsync(i => i.Email == email);
        }

        public void Save(User user)
        {
            Context.DbSetUser.Add(user);
        }

        public void Update(User user)
        {
            Context.Entry(user).State = EntityState.Modified;
        }

        public bool Delete(long userId)
        {
            var user = Context.DbSetUser.FirstOrDefault(i => i.Id == userId);

            if (user == null)
                return false;
            else
            {
                Context.DbSetUser.Remove(user);
                return true;
            }
        }
    }
}