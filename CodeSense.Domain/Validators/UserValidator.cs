using CodeSense.Domain.Entities;
using FluentValidation;

namespace CodeSense.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
    }
}