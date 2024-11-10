
using CandidateHub.Api.Presentation.Extensions;
using Carter;
using FluentValidation;

namespace CandidateHub.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDatabase(builder.Configuration);
            builder.Services.AddMemoryCache();
            builder.Services.AddDependencies();
            builder.Services.EnableSwagger();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddCarter();

            var app = builder.Build();
            app.ApplySwagger(builder.Environment);
            app.MapCarter();

            app.Run();
        }
    }
}
