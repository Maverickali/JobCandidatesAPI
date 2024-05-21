using FluentValidation;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Candidates.Dtos
{
    public class CreateCandidateCommandDtoValidator : AbstractValidator<CreateCandidateCommandDto>
    {
        private readonly JobCandidatesContext _context;

        public CreateCandidateCommandDtoValidator()
        {
            RuleFor(v => v.FirstName)
               .MaximumLength(3)
               .NotEmpty().WithMessage("FirstName is required.");
            RuleFor(v => v.LastName)
              .MaximumLength(3)
              .NotEmpty().WithMessage(errorMessage: "LastName is required.");

            RuleFor(v => v.Email)
              .NotEmpty().WithMessage("Email is required.")
              .EmailAddress().WithMessage("Invalid email format.")
              .MaximumLength(255)
              .WithMessage("Email must not exceed 255 characters.");
        }
    }
}