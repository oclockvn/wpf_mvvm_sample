using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Services;

namespace Core.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService authService;
        private readonly INavigationService navigationService;

        public LoginViewModel(IAuthService authService, INavigationService navigationService)
        {
            this.authService = authService;
            this.navigationService = navigationService;
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string userName;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string password;

        [RelayCommand(CanExecute = nameof(CanLogin))]
        private async Task LoginAsync()
        {
            // do login
            await Task.Delay(10);

            // nav to employee page
            var valid = await authService.IsValidAsync(UserName, Password);
            if (!valid)
            {
                // display message or sthing
            }
            else
            {
                // nav to employee list
                navigationService.NavigateTo(PageRoute.Employee);
            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
        }
    }
}
