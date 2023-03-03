using CommunityToolkit.Mvvm.ComponentModel;

namespace Core.Models
{
    public partial class Employee : ObservableObject
    {
        [ObservableProperty]
        private string firstName;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string phone;

        [ObservableProperty]
        private string gender;

        [ObservableProperty]
        private bool isRemote;

        [ObservableProperty]
        private string remoteLocation;
    }
}
