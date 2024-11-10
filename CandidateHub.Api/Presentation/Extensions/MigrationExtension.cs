using CandidateHub.Api.Infrastructure.Persistence;

namespace CandidateHub.Api.Presentation.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this WebApplication app, IWebHostEnvironment env)
        {
            //if (!env.IsDevelopment())
            //{
                using var scope = app.Services.CreateScope();
                var migrator = scope.ServiceProvider.GetRequiredService<CandidateDbContext>();
                var migrate = migrator.Migrate();
                if (!migrate)
                {
                    Console.WriteLine("Database migration failed. Check logs for details.");
                    Environment.Exit(1);
                }
            //}
        }
    }
}
