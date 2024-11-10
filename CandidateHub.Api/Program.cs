
using CandidateHub.Api.Presentation.Extensions;

namespace CandidateHub.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.EnableSwagger();

            var app = builder.Build();
            app.ApplySwagger(builder.Environment);

            app.Run();
        }
    }
}
