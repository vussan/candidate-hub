using CandidateHub.Api.Application.Abstractions.Repositories;
using CandidateHub.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandidateHub.Api.Infrastructure.Persistence.Repositories
{
    public class CandidateRepository(CandidateDbContext _context) : ICandidateRepository
    {
        public Task<List<Candidate>> GetAll()
        {
            return _context.Candidates.ToListAsync();
        }
        public async Task<Candidate?> GetByEmail(string email)
        {
            return await _context.Candidates.FirstOrDefaultAsync(c => c.Email == email);
        }
        public async Task<Candidate> Create(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            return candidate;
        }
        public Task<Candidate> Update(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            return Task.FromResult(candidate);
        }
    }
}
