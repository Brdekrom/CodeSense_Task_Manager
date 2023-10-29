using CodeSense.Domain.Entities;
using FluentValidation;

namespace CodeSense.Domain.Validators;

public class RequirementValidator : AbstractValidator<Requirement>
{
    public RequirementValidator()
    {
        RuleFor(x => x.Level)
            .NotEmpty().WithMessage("Level is required.")
            .Must(x => new[] { "Architect", "PM", "Senior Developer", "Medior Developer", "Junior Developer" }.Contains(x))
            .WithMessage("Level must be one of the following: Architect, PM, Senior developer, Junior developer");

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(1).WithMessage("Amount must be more than zero");
    }
}