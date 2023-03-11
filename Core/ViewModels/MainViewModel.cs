using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Core.ViewModels
{
    public class LogInUser
    {
        public bool Authenticated { get; set; }
        public string Username { get; set; }
    }

    public class LoginMessage : ValueChangedMessage<LogInUser>
    {
        public LoginMessage(LogInUser value) : base(value)
        {
        }
    }

    public partial class MainViewModel : ObservableObject, IRecipient<LoginMessage>
    {
        private readonly INavigationService navigationService;
        [ObservableProperty]
        private bool isLoggedIn;

        [ObservableProperty]
        private string username;

        public MainViewModel(IMessenger messenger, INavigationService navigationService)
        {
            messenger.Register<LoginMessage>(this);
            this.navigationService = navigationService;
        }

        public void Receive(LoginMessage message)
        {
            IsLoggedIn = message?.Value?.Authenticated == true;
            Username = message?.Value?.Username;
        }

        [RelayCommand]
        private void Logout()
        {
            IsLoggedIn = false;
            Username = null;

            navigationService.NavigateTo(PageRoute.Login);
        }
    }
}
