using FluentValidation;

namespace TimyApp.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeyCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeyCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");
        }
    }
}
