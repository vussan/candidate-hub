using Microsoft.OpenApi.Models;

namespace CandidateHub.Api.Presentation.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection EnableSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CandidateHub API",
                    Description = "Candidate Hub",
                });
            });

            return services;
        }
        public static IApplicationBuilder ApplySwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}
