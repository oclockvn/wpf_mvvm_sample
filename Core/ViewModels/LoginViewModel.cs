using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Core.Services;

namespace Core.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService authService;
        private readonly INavigationService navigationService;
        private readonly IMessenger messenger;

        public LoginViewModel(
            IAuthService authService,
            INavigationService navigationService,
            IMessenger messenger)
        {
            this.authService = authService;
            this.navigationService = navigationService;
            this.messenger = messenger;
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
                messenger.Send(new LoginMessage(new LogInUser
                {
                    Username = UserName,
                    Authenticated = true,
                }));

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
