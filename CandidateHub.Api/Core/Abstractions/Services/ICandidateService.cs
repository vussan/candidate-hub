using CandidateHub.Api.Application.DTOs;

namespace CandidateHub.Api.Core.Abstractions.Services
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidateDTO>> GetAll();
        Task CreateOrUpdateCandidate(CreateCandidateDTO candidateDTO);
    }
}
