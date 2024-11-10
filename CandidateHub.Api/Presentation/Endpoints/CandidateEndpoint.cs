using CandidateHub.Api.Application.DTOs;
using CandidateHub.Api.Core.Abstractions.Services;
using Carter;

namespace CandidateHub.Api.Presentation.Endpoints
{
    public class CandidateEndpoint : CarterModule
    {
        public CandidateEndpoint() : base("/api/candidates")
        {
            WithTags("Candidates");
        }
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", async (ICandidateService _candidateService) =>
            {
                return await _candidateService.GetAll();
            });

            app.MapPost("/", async (
                ICandidateService _candidateService,
                CreateCandidateDTO request) =>
            {
                await _candidateService.CreateOrUpdateCandidate(request);
                return Results.Ok();
            });
        }
    }
}
