using HomeApp.Domain.Services;
using System.Windows.Controls;

namespace UserProfilePlugin
{
    public partial class UserProfileControl : UserControl
    {
        private readonly IAuthenticationService _authService;

        public UserProfileControl(IAuthenticationService authService)
        {
            _authService = authService;
            _authService.PropertyChanged += (o, e) => UpdateTextBlock();

            InitializeComponent(); 
            UpdateTextBlock();
        }

        private void UpdateTextBlock()
        {
            textBlock.Text = _authService.CurrentUser is null ? "Not logged in." : "Hello, " + _authService.CurrentUser.FirstName + "!";
        }
    }
}