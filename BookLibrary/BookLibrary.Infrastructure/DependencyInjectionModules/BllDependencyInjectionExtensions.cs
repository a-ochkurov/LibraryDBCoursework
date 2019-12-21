using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Infrastructure.DependencyInjectionModules
{
    public static class BllDependencyInjectionExtensions
    {
        public static IServiceCollection ResolveBllDependencies(this IServiceCollection services)
        {
            //services.AddTransient<IBookService, BookService>();
            //services.AddTransient<ICollinsListService, CollinsListService>();
            //services.AddTransient<ICustomerService, CustomerService>();

            return services;
        }
    }
}
