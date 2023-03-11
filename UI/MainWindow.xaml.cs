using Core;
using Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using UI.Pages;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly INavigationService navigationService;

        public MainWindow()
        {
            
        }

        public MainWindow(MainViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();

            //this.navigationService = navigationService;

            // todo: refactor using behavior
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var navigationService = (Application.Current as App).Host.Services.GetRequiredService<INavigationService>();
            navigationService.NavigateTo(PageRoute.Login);
        }
    }
}
