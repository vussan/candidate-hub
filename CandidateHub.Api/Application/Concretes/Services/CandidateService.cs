using CandidateHub.Api.Application.Abstractions.Repositories;
using CandidateHub.Api.Application.DTOs;
using CandidateHub.Api.Core.Abstractions.Services;
using CandidateHub.Api.Core.Entities;

namespace CandidateHub.Api.Application.Concretes.Services
{
    public class CandidateService(ICandidateRepository _candidateRepository) : ICandidateService
    {
        public async Task<IEnumerable<CandidateDTO>> GetAll()
        {
            var candidates = await _candidateRepository.GetAll();
            var candidatesdto = candidates.Select(x => new CandidateDTO(
                Id: x.Id,
                FirstName: x.FirstName,
                LastName: x.LastName,
                Email: x.Email,
                PhoneNumber: x.PhoneNumber,
                Comment: x.Comment,
                GitHubUrl: x.GitHubUrl,
                LinkedInUrl: x.LinkedInUrl,
                PreferredCallTime: x.PreferredCallTime.ToString()
                )
            );

            return candidatesdto;
        }

        public async Task CreateOrUpdateCandidate(CreateCandidateDTO candidateDTO)
        {
            var existingCandidate = await _candidateRepository.GetByEmail(candidateDTO.Email);

            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidateDTO.FirstName;
                existingCandidate.LastName = candidateDTO.LastName;
                existingCandidate.PhoneNumber = candidateDTO.PhoneNumber;
                existingCandidate.PreferredCallTime = candidateDTO.PreferredCallTime == null ? null : TimeOnly.Parse(candidateDTO.PreferredCallTime);
                existingCandidate.Comment = candidateDTO.Comment;
                existingCandidate.GitHubUrl = candidateDTO.GitHubUrl;
                existingCandidate.LinkedInUrl = candidateDTO.LinkedInUrl;
                await _candidateRepository.Update(existingCandidate);
            }
            else
            {
                var candidate = new Candidate()
                {
                    FirstName = candidateDTO.FirstName,
                    LastName = candidateDTO.LastName,
                    Email = candidateDTO.Email,
                    PreferredCallTime = candidateDTO.PreferredCallTime == null ? null : TimeOnly.Parse(candidateDTO.PreferredCallTime),
                    PhoneNumber = candidateDTO.PhoneNumber,
                    GitHubUrl = candidateDTO.GitHubUrl,
                    LinkedInUrl = candidateDTO.LinkedInUrl,
                    Comment = candidateDTO.Comment
                };
                await _candidateRepository.Create(candidate);
            }
        }
    }
}
