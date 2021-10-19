using HomeApp.Db;
using HomeApp.Domain.Models;
using HomeApp.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Threading.Tasks;

namespace HomeApp.Services
{
    public class AuthenticationService : IAuthenticationService, INotifyPropertyChanged
    {
        private readonly HomeAppContext _context;

        public event PropertyChangedEventHandler PropertyChanged;

        private HomeAppUser _currentUser;
        public HomeAppUser CurrentUser
        {
            get => _currentUser;
            private set
            {
                _currentUser = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentUser)));
            }
        }

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            private set
            {
                _isLoggedIn = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLoggedIn)));
            }
        }

        public AuthenticationService(HomeAppContext context)
        {
            _context = context;
        }

        public async Task<HomeAppUser> Login()
        {
            CurrentUser = await _context.Users.FirstOrDefaultAsync(x => x.Username == "emclaughlin");
            _isLoggedIn = CurrentUser != null;
            return CurrentUser;
        }

        public void Logout()
        {
            _isLoggedIn = false;
            CurrentUser = null;
        }
    }
}
