using Core;
using Microsoft.Extensions.DependencyInjection;
using UI.Pages;

namespace UI
{
    internal static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            return services
                .AddScoped<LoginPage>()
                .AddScoped<EmployeePage>()
                .AddScoped<INavigationService, NavigationService>()
                ;
        }
    }
}
