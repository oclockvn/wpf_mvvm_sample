using Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IHost Host { get; private set; }

        public App()
        {
            Host = new HostBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddCoreServices();
                    services.AddUIServices();

                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await Host.StartAsync();

            var mainWindow = Host.Services.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
