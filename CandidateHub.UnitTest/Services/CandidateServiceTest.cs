using CandidateHub.Api.Application.Abstractions.Repositories;
using CandidateHub.Api.Application.Abstractions;
using CandidateHub.Api.Application.Concretes.Services;
using CandidateHub.Api.Application.DTOs;
using CandidateHub.Api.Core.Entities;
using Moq;

namespace CandidateHub.UnitTest.Services
{
    public class CandidateServiceTest
    {
        private readonly Mock<ICandidateRepository> _mockCandidateRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CandidateService _candidateService;

        public CandidateServiceTest()
        {
            _mockCandidateRepository = new Mock<ICandidateRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _candidateService = new CandidateService(_mockCandidateRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task CreateOrUpdateCandidate_CandidateDoesNotExist_CreatesCandidate()
        {
            // Arrange
            var candidateDTO = new CreateCandidateDTO
            (
                Email: "new@example.com",
                FirstName: "FirstName",
                LastName: "LastName",
                PhoneNumber: "987654321",
                PreferredCallTime: "14:00",
                Comment: "New comment",
                GitHubUrl: "https://github.com/newuser",
                LinkedInUrl: "https://linkedin.com/in/newuser"
            );

            _mockCandidateRepository
                .Setup(repo => repo.GetByEmail(candidateDTO.Email))
                .ReturnsAsync((Candidate?)null);

            // Act
            await _candidateService.CreateOrUpdateCandidate(candidateDTO);

            // Assert
            _mockCandidateRepository.Verify(repo => repo.Create(It.Is<Candidate>(c =>
                c.Email == candidateDTO.Email &&
                c.FirstName == candidateDTO.FirstName &&
                c.LastName == candidateDTO.LastName &&
                c.PhoneNumber == candidateDTO.PhoneNumber &&
                c.PreferredCallTime == TimeOnly.Parse(candidateDTO.PreferredCallTime!) &&
                c.Comment == candidateDTO.Comment &&
                c.GitHubUrl == candidateDTO.GitHubUrl &&
                c.LinkedInUrl == candidateDTO.LinkedInUrl
            )), Times.Once);

            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateOrUpdateCandidate_CandidateExists_UpdatesCandidate()
        {
            // Arrange
            string email = "test@example.com";
            var existingCandidate = new Candidate
            {
                Id = Guid.NewGuid(),
                Email = email,
                FirstName = "OldFirstName",
                LastName = "OldLastName",
                Comment = "Random old Comment"
            };

            var candidateDTO = new CreateCandidateDTO
            (
                Email: email,
                FirstName: "NewFirstName",
                LastName: "NewLastName",
                PhoneNumber: "123456789",
                PreferredCallTime: "10:00",
                Comment: "Updated comment",
                GitHubUrl: "https://github.com/example",
                LinkedInUrl: "https://linkedin.com/in/example"
            );

            _mockCandidateRepository
                .Setup(repo => repo.GetByEmail(candidateDTO.Email))
                .ReturnsAsync(existingCandidate);

            // Act
            await _candidateService.CreateOrUpdateCandidate(candidateDTO);

            // Assert
            // Verify that the Update method was called with the expected candidate object
            _mockCandidateRepository.Verify(repo => repo.Update(It.Is<Candidate>(c =>
                c.Id == existingCandidate.Id &&
                c.FirstName == candidateDTO.FirstName &&
                c.LastName == candidateDTO.LastName &&
                c.PhoneNumber == candidateDTO.PhoneNumber &&
                c.PreferredCallTime == TimeOnly.Parse(candidateDTO.PreferredCallTime!) &&
                c.Comment == candidateDTO.Comment &&
                c.GitHubUrl == candidateDTO.GitHubUrl &&
                c.LinkedInUrl == candidateDTO.LinkedInUrl
            )), Times.Once);

            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
