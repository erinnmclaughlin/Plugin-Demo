using HomeApp.Domain.Models;
using HomeApp.Domain.Repositories;
using HomeApp.Domain.Services;
using System.ComponentModel;
using System.Threading.Tasks;

namespace HomeApp.Services
{
    public class AuthenticationService : IAuthenticationService, INotifyPropertyChanged
    {
        private readonly IUserRepository _userRepo;

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

        public AuthenticationService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<HomeAppUser> Login()
        {
            CurrentUser = await _userRepo.GetUserByUsername("emclaughlin");
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
