﻿using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Candidate : BaseAuditableEntity
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? PreferredCallTime { get; set; }
        public string? LinkedInProfile { get; set; }
        public string? GitHubProfile { get; set; }

        [Required]
        public string FreeTextComment { get; set; }
    }
}