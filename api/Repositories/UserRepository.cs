using api.Contracts;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    { 
        public UserRepository(ApplicationDbContext _context) : base(_context) { }
    

        public void DeleteUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await FindAll()
                   .OrderBy(u => u.UserName)
                   .ToListAsync();
        }
        public async Task<AppUser> GetUserAsync(string id)
        {
            return await FindByCondition(u => u.Id.Equals(id))
                   .SingleOrDefaultAsync();
        }
    }
}
