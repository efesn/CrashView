using CrashView.Dto.Request;
using FluentValidation;

namespace CrashView.Validators
{
    public class CrashValidator : AbstractValidator<CrashRequestDto>
    {
        public CrashValidator()
        {
            RuleFor(x => x.CrashDescription)
                .NotEmpty().WithMessage("Crash description is required.")
                .MaximumLength(300).WithMessage("Crash description cannot exceed 300 characters.");

            RuleFor(x => x.Impact)
                .NotEmpty().WithMessage("Impact is required.")
                .MaximumLength(20).WithMessage("Impact cannot exceed 20 characters.");

            RuleFor(x => x.CrashDate)
                .NotEmpty().WithMessage("Crash date is required.");
        }
    }
}
