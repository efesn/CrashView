using CrashView.Entities;
using FluentValidation;

namespace CrashView.Validators
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.Team_ID)
                .GreaterThan(0).WithMessage("Team ID must be greater than 0.");

            RuleFor(x => x.Team_Name)
                .NotEmpty().WithMessage("Team name is required.")
                .MaximumLength(50).WithMessage("Team name cannot exceed 50 characters.");

            RuleFor(x => x.Base_Country)
                .NotEmpty().WithMessage("Base country is required.")
                .MaximumLength(50).WithMessage("Base country cannot exceed 50 characters.");
        }
    }
}
