using CandidateHub.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandidateHub.Api.Infrastructure.Persistence
{
    public sealed class CandidateDbContext(DbContextOptions<CandidateDbContext> options) : DbContext(options)
    {
        public DbSet<Candidate> Candidates { get; set; }
    }
}
