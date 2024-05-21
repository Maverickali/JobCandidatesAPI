using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Candidates.Commands
{
    public record CreateCandidateCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PreferredCallTime { get; set; }
        public string LinkedInProfile { get; set; }
        public string GitHubProfile { get; set; }
        public string FreeTextComment { get; set; }
    }

    public class CreateCandidate : IRequestHandler<CreateCandidateCommand, int>
    {
        private readonly JobCandidatesContext _context;

        public CreateCandidate(JobCandidatesContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
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