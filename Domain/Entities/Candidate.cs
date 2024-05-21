using Domain.Common;
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

        public string? Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? PreferredCallTime { get; set; }
        public string? LinkedInProfile { get; set; }
        public string? GitHubProfile { get; set; }

        [Required]
        public string FreeTextComment { get; set; }
    }
}