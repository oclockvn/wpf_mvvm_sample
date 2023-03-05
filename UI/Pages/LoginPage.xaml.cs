using Core.ViewModels;
using System.Windows.Controls;

namespace UI.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage(LoginViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
