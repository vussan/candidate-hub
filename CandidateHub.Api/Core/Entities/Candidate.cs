namespace CandidateHub.Api.Core.Entities
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
        public TimeOnly? PreferredCallTime { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public required string Comment { get; set; }
    }
}
