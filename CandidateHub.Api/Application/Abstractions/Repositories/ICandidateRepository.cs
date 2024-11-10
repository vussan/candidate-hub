using CandidateHub.Api.Core.Entities;

namespace CandidateHub.Api.Application.Abstractions.Repositories
{
    public interface ICandidateRepository
    {
        Task<List<Candidate>> GetAll();
        Task<Candidate?> GetByEmail(string email);
        Task<Candidate> Create(Candidate candidate);
        Task<Candidate> Update(Candidate candidate);
    }
}
