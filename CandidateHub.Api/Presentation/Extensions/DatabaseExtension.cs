using CandidateHub.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CandidateHub.Api.Presentation.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SQLiteConnection")!;
            services.AddDbContext<CandidateDbContext>(options => options.UseSqlite(connectionString));

            return services;
        }
    }
}
