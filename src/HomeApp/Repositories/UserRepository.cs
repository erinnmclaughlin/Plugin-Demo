using HomeApp.Db;
using HomeApp.Domain.Models;
using HomeApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HomeAppContext _context;

        public UserRepository(HomeAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HomeAppUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<HomeAppUser> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
