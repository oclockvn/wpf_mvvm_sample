using CommunityToolkit.Mvvm.Messaging;
using Core.Services;
using Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            return services
                .AddScoped<LoginViewModel>()
                .AddScoped<EmployeeViewModel>()
                .AddScoped<MainViewModel>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<IMessenger, WeakReferenceMessenger>()
                ;
        }
    }
}