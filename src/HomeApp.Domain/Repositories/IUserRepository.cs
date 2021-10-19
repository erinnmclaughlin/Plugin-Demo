using HomeApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApp.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<HomeAppUser>> GetAllUsers();
        Task<HomeAppUser> GetUserByUsername(string username);
    }
}
