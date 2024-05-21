using Application.Candidates.Dtos;
using Domain.Entities;
using FluentValidation.TestHelper;
using Xunit;

namespace JobCandidatesAPI.Tests
{
    public class CandidateValidatorTests
    {
        private readonly CreateCandidateCommandDtoValidator _validator;

        public CandidateValidatorTests()
        {
            _validator = new CreateCandidateCommandDtoValidator();
        }

        [Fact]
        public void Should_Have_Error_When_FirstName_Is_Empty()
        {
            var dto = new CreateCandidateCommandDto { FirstName = string.Empty };
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.FirstName)
                .WithErrorMessage("FirstName is required.");
        }

        [Fact]
        public void Should_Have_Error_When_FirstName_Exceeds_MaxLength()
        {
            var dto = new CreateCandidateCommandDto { FirstName = "John" };
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.FirstName)
                .WithErrorMessage("The length of 'First Name' must be 3 characters or fewer. You entered 4 characters.");
        }

        [Fact]
        public void Should_Not_Have_Error_When_FirstName_Is_Valid()
        {
            var dto = new CreateCandidateCommandDto { FirstName = "Jon" };
            var result = _validator.TestValidate(dto);
            result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void Should_Have_Error_When_LastName_Is_Empty()
        {
            var dto = new CreateCandidateCommandDto { LastName = string.Empty };
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.LastName)
                .WithErrorMessage("LastName is required.");
        }

        [Fact]
        public void Should_Have_Error_When_LastName_Exceeds_MaxLength()
        {
            var dto = new CreateCandidateCommandDto { LastName = "Doe" };
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.LastName)
                .WithErrorMessage("The length of 'Last Name' must be 3 characters or fewer. You entered 3 characters.");
        }

        [Fact]
        public void Should_Not_Have_Error_When_LastName_Is_Valid()
        {
            var dto = new CreateCandidateCommandDto { LastName = "Doe" };
            var result = _validator.TestValidate(dto);
            result.ShouldNotHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Empty()
        {
            var dto = new CreateCandidateCommandDto { Email = string.Empty };
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage("Email is required.");
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Invalid()
        {
            var dto = new CreateCandidateCommandDto { Email = "invalid-email" };
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage("Invalid email format.");
        }

        [Fact]
        public void Should_Have_Error_When_Email_Exceeds_MaxLength()
        {
            var dto = new CreateCandidateCommandDto { Email = new string('a', 256) + "@example.com" };
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage("Email must not exceed 255 characters.");
        }

        [Fact]
        public void Should_Not_Have_Error_When_Email_Is_Valid()
        {
            var dto = new CreateCandidateCommandDto { Email = "valid@example.com" };
            var result = _validator.TestValidate(dto);
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }
    }
}