using AutoMapper;
using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
using CodeSense.Domain.Validators;
using CodeSense.Domain.ValueObjects;
using FluentValidation;
using MediatR;

namespace CodeSense.Application.Handlers.Users.Commands;

public class CreateUserCommand : IRequest<int>
{
    public UserContactData ContactData { get; set; }
    public LoginData LoginData { get; set; }
    public bool IsAdmin { get; set; }
}

public class CreateUserCommandHandler(IRepository<User> userService, IMapper mapper) : IRequestHandler<CreateUserCommand, int>
{
    private readonly IRepository<User> _userService = userService;

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.ContactData, request.LoginData, request.IsAdmin);

        await Validate(user);

        user = await _userService.CreateAsync(user);

        return user.Id;
    }

    private async Task Validate(User user)
    {
        var checkExistence = await _userService.GetByEmailAsync(user.GetEmail());

        if (checkExistence is not null)
        {
            throw new ValidationException("Email already exists");
        }

        var validator = new UserValidator();
        var result = validator.Validate(user);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
    }
}