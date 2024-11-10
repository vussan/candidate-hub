using CandidateHub.Api.Application.Abstractions.Repositories;
using CandidateHub.Api.Core.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CandidateHub.Api.Infrastructure.Persistence.CachedRepositories
{
    public class CachedCandidateRepository(ICandidateRepository _decoratedRepository, IMemoryCache _cache) : ICandidateRepository
    {
        public async Task<List<Candidate>> GetAll() => await _decoratedRepository.GetAll();

        public async Task<Candidate?> GetByEmail(string email)
        {
            string key = $"candidate-{email.ToLower()}";
            return await _cache.GetOrCreateAsync(
                key,
                async entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                    var result = await _decoratedRepository.GetByEmail(email);
                    if (result != null)
                    {
                        entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                    }
                    return result;
                });
        }

        public async Task<Candidate> Create(Candidate candidate)
        {
            var decoratedCandidate = await _decoratedRepository.Create(candidate);

            string key = $"candidate-{candidate.Email.ToLower()}";
            _cache.Set(key, decoratedCandidate, TimeSpan.FromMinutes(5));

            return decoratedCandidate;
        }

        public async Task<Candidate> Update(Candidate candidate)
        {
            var decoratedCandidate = await _decoratedRepository.Update(candidate);

            string key = $"candidate-{candidate.Email.ToLower()}";
            _cache.Set(key, decoratedCandidate, TimeSpan.FromMinutes(5));

            return decoratedCandidate;
        }
    }
}
