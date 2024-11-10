using CandidateHub.Api.Application.DTOs;
using FluentValidation;

namespace CandidateHub.Api.Application.Concretes.Validators
{
    public class CreateCandidateValidator : AbstractValidator<CreateCandidateDTO>
    {
        public CreateCandidateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment is required");

            RuleFor(x => x.PreferredCallTime)
                .Matches(@"^\d{2}:\d{2}$").WithMessage("Preferred call time must be in the format HH:mm.");
        }
    }
}
