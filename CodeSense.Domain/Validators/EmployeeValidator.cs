using CodeSense.Domain.Common.Enum;
using CodeSense.Domain.Entities;
using FluentValidation;

namespace CodeSense.Domain.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(20).WithMessage("Name cannot be longer than 20 characters.");

        RuleFor(x => x.Level)
            .NotEmpty().WithMessage("Level is required.")
            .Must(x => new[] { EmployeeLevel.Junior, EmployeeLevel.Medior, EmployeeLevel.Senior, EmployeeLevel.Architect, EmployeeLevel.PM }.Contains(x))
            .WithMessage("Level must be one of the following: Junior Developer, Medior Developer, Senior Developer, Architect, PM");

        RuleFor(x => x.FinancialData.DailySalary)
            .GreaterThanOrEqualTo(1).WithMessage("Cost must be zero or greater.");

        RuleFor(x => x.Availability.From)
            .NotEmpty().WithMessage("Available From date is required.");

        RuleFor(x => x.Availability.Until)
            .NotEmpty().WithMessage("Available Until date is required.")
            .GreaterThan(x => x.Availability.Until).WithMessage("Available Until must be after Available From.");
    }
}