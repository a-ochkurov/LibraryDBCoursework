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
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IReaderService, ReaderService>();
            services.AddTransient<IBorrowService, BorrowService>();

            return services;
        }
    }
}
