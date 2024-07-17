using CrashView.Entities;
using FluentValidation;

namespace CrashView.Validators
{
    public class TrackValidator : AbstractValidator<Track>
    {
        public TrackValidator()
        {
            RuleFor(x => x.Track_Name)
                .NotEmpty().WithMessage("Track Name is required")
                .MaximumLength(100).WithMessage("Track Name cannot exceed 100 characters");
            RuleFor(x => x.Continent)
                .NotEmpty().WithMessage("Continent is required")
                .MaximumLength(50).WithMessage("Continent cannot exceed 50 characters");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required")
                .MaximumLength(50).WithMessage("Country cannot exceed 50 characters");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required")
                .MaximumLength(50).WithMessage("City cannot exceed 50 characters");
            RuleFor(x => x.Number_Of_Laps)
                .GreaterThan(0).WithMessage("Number of Laps must be greater than 0")
                .NotEmpty().WithMessage("Number of Laps is required");
            RuleFor(x => x.Fastest_Lap_Record)
                .NotEmpty().WithMessage("Fastest Lap Record is required");
        }


    }
}
