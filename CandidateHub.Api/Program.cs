
using CandidateHub.Api.Presentation.Extensions;
using Carter;

namespace CandidateHub.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDatabase(builder.Configuration);
            builder.Services.AddDependencies();
            builder.Services.EnableSwagger();
            builder.Services.AddCarter();

            var app = builder.Build();
            app.ApplySwagger(builder.Environment);
            app.MapCarter();

            app.Run();
        }
    }
}
