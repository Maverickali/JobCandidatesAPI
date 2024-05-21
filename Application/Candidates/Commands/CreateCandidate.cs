using Application.Candidates.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Candidates.Commands
{
    public class CreateCandidate : IRequestHandler<CreateCandidateCommandDto, int>
    {
        private readonly JobCandidatesContext _context;

        public CreateCandidate(JobCandidatesContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCandidateCommandDto request, CancellationToken cancellationToken)
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
    }
}