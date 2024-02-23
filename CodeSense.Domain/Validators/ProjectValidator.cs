using CodeSense.Domain.Entities;
using FluentValidation;

namespace CodeSense.Domain.Validators;

public class ProjectValidator : AbstractValidator<Project>
{
    public ProjectValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

        RuleFor(x => x.Profit)
            .GreaterThanOrEqualTo(1).WithMessage("Profit must be more than zero.");

        RuleFor(x => x.Deadline)
            .NotEmpty().WithMessage("Deadline date is required.");

        RuleFor(x => x.Requirements)
            .NotNull().WithMessage("Requirements cannot be null.")
            .Must(list => list.Count > 0).WithMessage("Requirements list must have at least one item.")
            .ForEach(rule => rule.SetValidator(new RequirementValidator()));
    }
}