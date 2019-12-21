using BookLibrary.DAL.DbContext;
using BookLibrary.DAL.Interfaces;
using BookLibrary.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Infrastructure.DependencyInjectionModules
{
    public static class DalDependencyInjectionExtensions
    {
        public static IServiceCollection ResolveDalDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<LibraryDbContext>(c => new LibraryDbContext(connectionString));
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorsRepository, AuthorsRepository>();

            return services;
        }
    }
}
