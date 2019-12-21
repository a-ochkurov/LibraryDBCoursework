using BookLibrary.BLL.Interfaces;
using BookLibrary.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Infrastructure.DependencyInjectionModules
{
    public static class BllDependencyInjectionExtensions
    {
        public static IServiceCollection ResolveBllDependencies(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();

            return services;
        }
    }
}
