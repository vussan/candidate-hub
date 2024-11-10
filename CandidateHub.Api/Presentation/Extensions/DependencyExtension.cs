using CandidateHub.Api.Application.Abstractions.Repositories;
using CandidateHub.Api.Application.Concretes.Services;
using CandidateHub.Api.Core.Abstractions.Services;
using CandidateHub.Api.Infrastructure.Persistence.Repositories;

namespace CandidateHub.Api.Presentation.Extensions
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ICandidateService, CandidateService>();

            return services;
        }
    }
}
