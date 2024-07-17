using FluentValidation;
using CrashView.Dto.Request;

namespace CrashView.Validators
{
    public class PersonValidator : AbstractValidator<PersonsRequestDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.First_Name)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.Last_Name)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Age must be greater than 0.")
                .Must(LegalAge).WithMessage("Age must be at least 18 years old.");

            RuleFor(x => x.Nationality)
                .NotEmpty().WithMessage("Nationality is required.")
                .MaximumLength(50).WithMessage("Nationality cannot exceed 50 characters.");

            RuleFor(x => x.Role_ID)
                .NotEmpty().WithMessage("Role ID is required.")
                .GreaterThan(0).WithMessage("Role ID must be greater than 0.");
        }
        private bool LegalAge(int age)
        {
            return age >= 18;
        }
    }
}
