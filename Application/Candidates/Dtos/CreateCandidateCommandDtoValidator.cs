using FluentValidation;

namespace Application.Candidates.Dtos
{
    public class CreateCandidateCommandDtoValidator : AbstractValidator<CreateCandidateCommandDto>
    {
        public CreateCandidateCommandDtoValidator()
        {
            RuleFor(v => v.FirstName)
               .MinimumLength(3)
               .NotEmpty().WithMessage("FirstName is required.");
            RuleFor(v => v.LastName)
              .MinimumLength(3)
              .NotEmpty().WithMessage(errorMessage: "LastName is required.");

            RuleFor(v => v.Email)
              .NotEmpty().WithMessage("Email is required.")
              .EmailAddress().WithMessage("Invalid email format.")
              .MaximumLength(255)
              .WithMessage("Email must not exceed 255 characters.");
        }
    }
}