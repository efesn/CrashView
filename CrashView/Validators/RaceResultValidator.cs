using CrashView.Dto.Request;
using FluentValidation;

namespace CrashView.Validators
{
    public class RaceResultValidator : AbstractValidator<RaceResultRequestDto>
    {
        public RaceResultValidator()
        {
            RuleFor(x => x.Race_ID)
                .GreaterThan(0).WithMessage("Race ID must be greater than 0.")
                .NotEmpty().WithMessage("Race ID is required.");

            RuleFor(x => x.Person_ID)
                .GreaterThan(0).WithMessage("Person ID must be greater than 0.")
                .NotEmpty().WithMessage("Person ID is required.");  

            RuleFor(x => x.Position)
                .GreaterThanOrEqualTo(1).WithMessage("Position must be at least 1.")
                .NotEmpty().WithMessage("Position is required.");

        }
    }
}


