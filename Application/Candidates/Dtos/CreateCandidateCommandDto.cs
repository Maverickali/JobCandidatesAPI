﻿using MediatR;

namespace Application.Candidates.Dtos
{
    public record CreateCandidateCommandDto : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PreferredCallTime { get; set; }
        public string LinkedInProfile { get; set; }
        public string GitHubProfile { get; set; }
        public string FreeTextComment { get; set; }
    }
}