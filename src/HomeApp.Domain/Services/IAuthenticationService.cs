using HomeApp.Domain.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace HomeApp.Domain.Services
{
    public interface IAuthenticationService : INotifyPropertyChanged
    {
        bool IsLoggedIn { get; }

        HomeAppUser CurrentUser { get; }
        Task<HomeAppUser> Login();
        void Logout();
    }
}
