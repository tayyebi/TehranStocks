using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TehranStocks.Database.Repositories;
using TehranStocks.Domain.RepositoriesInterfaces;

namespace TehranStocks
{
    public static class StartupExtended
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
        }
    }
}