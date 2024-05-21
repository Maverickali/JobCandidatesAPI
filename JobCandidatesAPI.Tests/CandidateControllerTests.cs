using Application.Candidates.Commands;
using Application.Candidates.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using JobCandidatesAPI.Controllers;

namespace JobCandidatesAPI.Tests
{
    public class CandidateControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CandidateController _controller;

        public CandidateControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new CandidateController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Post_ReturnsOk_WithCandidate()
        {
            var command = new CreateCandidateCommandDto
            {
                FirstName = "Collins",
                LastName = "Doe",
                Email = "collins.ddumba@example.com",
                PhoneNumber = "1234567890",
                PreferredCallTime = DateTime.Now,
                LinkedInProfile = "https://linkedin.com/in/Collinsdoe",
                GitHubProfile = "https://github.com/Collinsdoe",
                FreeTextComment = "A skilled developer."
            };

            var candidate = new Candidate
            {
                Id = 1,
                FirstName = "Collins",
                LastName = "Doe",
                Email = "collins.ddumba@example.com",
                PhoneNumber = "1234567890",
                PreferredCallTime = DateTime.Now,
                LinkedInProfile = "https://linkedin.com/in/Collinsdoe",
                GitHubProfile = "https://github.com/Collinsdoe",
                FreeTextComment = "A skilled developer."
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCandidateCommandDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(candidate.Id)
                ;

            var result = await _controller.Post(command);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedCandidate = Assert.IsType<int>(okResult.Value);
            //Assert.Equal(candidate.Id, returnedCandidate.Id);
            //Assert.Equal(candidate.FirstName, returnedCandidate.FirstName);
            //Assert.Equal(candidate.LastName, returnedCandidate.LastName);
            //Assert.Equal(candidate.Email, returnedCandidate.Email);
            //Assert.Equal(candidate.PhoneNumber, returnedCandidate.PhoneNumber);
            //Assert.Equal(candidate.PreferredCallTime, returnedCandidate.PreferredCallTime);
            //Assert.Equal(candidate.LinkedInProfile, returnedCandidate.LinkedInProfile);
            //Assert.Equal(candidate.GitHubProfile, returnedCandidate.GitHubProfile);
            //Assert.Equal(candidate.FreeTextComment, returnedCandidate.FreeTextComment);
        }
    }
}