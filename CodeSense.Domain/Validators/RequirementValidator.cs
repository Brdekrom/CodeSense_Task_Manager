using CodeSense.Domain.Common.Constants;
using CodeSense.Domain.Entities;
using FluentValidation;

namespace CodeSense.Domain.Validators;

public class RequirementValidator : AbstractValidator<Requirement>
{
    public RequirementValidator()
    {
        RuleFor(x => x.Level)
            .NotEmpty().WithMessage("Level is required.")
            .Must(x => new[] { EmployeeLevel.Junior, EmployeeLevel.Medior, EmployeeLevel.Senior, EmployeeLevel.Architect, EmployeeLevel.PM }.Contains(x))
            .WithMessage("Level must be one of the following: Junior Developer, Medior Developer, Senior Developer, Architect, PM");

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(1).WithMessage("Amount must be more than zero");
    }
}