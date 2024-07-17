using CrashView.Entities;
using FluentValidation;

namespace CrashView.Validators
{
    public class RoleValidatior : AbstractValidator<Role>
    {
        public RoleValidatior()
        {
            RuleFor(x => x.Role_ID)
                .GreaterThan(0).WithMessage("Role ID must be greater than 0.");

            RuleFor(x => x.Role_Name)
                .NotEmpty().WithMessage("Role name is required.")
                .MaximumLength(50).WithMessage("Role name cannot exceed 50 characters.");
        }
    }
}
