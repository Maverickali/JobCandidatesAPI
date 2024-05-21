using Application.Candidates.Dtos;
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
    public class CreateCandidate : IRequestHandler<CreateCandidateCommandDto, int>
    {
        private readonly JobCandidatesContext _context;

        public CreateCandidate(JobCandidatesContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCandidateCommandDto request, CancellationToken cancellationToken)
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