using CandidateHub.Api.Application.DTOs;
using CandidateHub.Api.Core.Abstractions.Services;
using Carter;
using FluentValidation;

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
            app.MapGet("/", async (ICandidateService candidateService) =>
            {
                return await candidateService.GetAll();
            });

            app.MapPost("/", async (
                IValidator<CreateCandidateDTO> validator,
                ICandidateService candidateService,
                CreateCandidateDTO request) =>
            {
                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid)
                    return Results.BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).First());

                await candidateService.CreateOrUpdateCandidate(request);
                return Results.Ok();
            });
        }
    }
}
