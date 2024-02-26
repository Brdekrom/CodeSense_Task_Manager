using CodeSense.Domain.Entities;
using FluentValidation;

namespace CodeSense.Domain.Validators;

public class ProjectValidator : AbstractValidator<Project>
{
    public ProjectValidator()
    {
    }
}