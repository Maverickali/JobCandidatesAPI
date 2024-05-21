using Application.Candidates.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Candidates.Commands
{
    public class CreateCandidate : IRequestHandler<CreateCandidateCommandDto, int>
    {
        private readonly JobCandidatesContext _context;
        private readonly ILogger<CreateCandidate> _logger;

        public CreateCandidate(JobCandidatesContext context, ILogger<CreateCandidate> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCandidateCommandDto request, CancellationToken cancellationToken)
        {
            try
            {
                var existingCandidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Email == request.Email);

                if (existingCandidate != null)
                {
                    existingCandidate.FirstName = request.FirstName;
                    existingCandidate.LastName = request.LastName;
                    existingCandidate.PhoneNumber = request.PhoneNumber;
                    existingCandidate.PreferredCallTime = request.PreferredCallTime;
                    existingCandidate.FreeTextComment = request.FreeTextComment;
                    existingCandidate.LinkedInProfile = request.LinkedInProfile;
                    existingCandidate.GitHubProfile = request.GitHubProfile;
                    existingCandidate.LastModified = DateTime.Now;
                    await _context.SaveChangesAsync(cancellationToken);
                    return existingCandidate.Id;
                }
                var entity = new Candidate
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    PreferredCallTime = request.PreferredCallTime,
                    LinkedInProfile = request.LinkedInProfile,
                    GitHubProfile = request.GitHubProfile,
                    FreeTextComment = request.FreeTextComment,
                    Created = DateTime.Now
                };

                _context.Add<Candidate>(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error Message - {ex.Message}");
            }
            return 0;
        }
    }
}