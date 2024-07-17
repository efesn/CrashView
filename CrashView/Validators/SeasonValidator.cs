using CrashView.Entities;
using FluentValidation;

namespace CrashView.Validators
{
    public class SeasonValidator : AbstractValidator<Season>
    {
        public SeasonValidator()
        {
            RuleFor(x => x.Season_ID)
                .GreaterThan(0).WithMessage("Season ID must be greater than 0.");

            RuleFor(x => x.Season_Name)
                .NotEmpty().WithMessage("Season name is required.")
                .MaximumLength(50).WithMessage("Season name cannot exceed 50 characters.");

            RuleFor(x => x.Start_Date)
                .NotEmpty().WithMessage("Start date is required.");

            RuleFor(x => x.End_Date)
                .NotEmpty().WithMessage("End date is required.");
        }
    }
}
