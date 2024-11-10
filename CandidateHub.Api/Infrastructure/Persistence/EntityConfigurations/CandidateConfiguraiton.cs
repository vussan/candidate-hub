using CandidateHub.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidateHub.Api.Infrastructure.Persistence.EntityConfigurations
{
    public class CandidateConfiguraiton : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(p => p.FirstName)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.Property(p => p.LastName)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.Property(p => p.PhoneNumber)
                   .HasMaxLength(15);

            builder.Property(p => p.LinkedInUrl)
                   .HasMaxLength(100);

            builder.Property(p => p.GitHubUrl)
                   .HasMaxLength(100);

            builder.Property(p => p.Comment)
                   .HasMaxLength(1000);
        }
    }
}
