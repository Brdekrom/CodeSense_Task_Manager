using CodeSense.Domain.ValueObjects;
using FluentValidation;

namespace CodeSense.Domain.Validators;

public class RequirementValidator : AbstractValidator<Requirement>
{
    public RequirementValidator()
    {
    }
}