using Contracts;
using Repository;

namespace TraineAPI.Extentation
{
    public static class ServiceExtensions
    {

        public static void ConfigreRepositoryManegar(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManegar, RepositoryManegar>();
        }
    }
}
