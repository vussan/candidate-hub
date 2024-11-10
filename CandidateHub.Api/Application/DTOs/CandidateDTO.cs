namespace CandidateHub.Api.Application.DTOs
{
    public record CandidateDTO
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string? PhoneNumber,
        string? PreferredCallTime,
        string? LinkedInUrl,
        string? GitHubUrl,
        string Comment
    );
}
