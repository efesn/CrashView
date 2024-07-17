using FluentValidation;
using CrashView.Dto.Request;

namespace CrashView.Validators
{
    public class RaceValidator : AbstractValidator<RaceRequestDto>
    {
        public RaceValidator()
        {
            RuleFor(x => x.Race_Name)
                .NotEmpty().WithMessage("Race name is required.")
                .MaximumLength(100).WithMessage("Race name cannot exceed 100 characters.");

            RuleFor(x => x.Season_ID)
                .GreaterThan(0).WithMessage("Season ID must be greater than 0.");

            RuleFor(x => x.Track_ID)
                .GreaterThan(0).WithMessage("Track ID must be greater than 0.");

            RuleFor(x => x.Race_Date)
                .NotEmpty().WithMessage("Race date is required.");

        }
    }
}
