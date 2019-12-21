using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Infrastructure.DependencyInjectionModules
{
    public static class DalDependencyInjectionExtensions
    {
        public static IServiceCollection ResolveDalDependencies(this IServiceCollection services, string connectionString)
        {
            //services.AddScoped<HarperCollinsDbContext>(c => new HarperCollinsDbContext(connectionString));
            //services.AddTransient<IRepository<CollinsList>, CollinsListRepository>();
            //services.AddTransient<ICustomerRepository, CustomerRepository>();
            //services.AddTransient<IBookRepository, BookRepository>();

            return services;
        }
    }
}
