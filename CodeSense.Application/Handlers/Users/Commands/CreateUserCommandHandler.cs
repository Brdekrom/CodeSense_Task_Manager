using AutoMapper;
using CodeSense.Application.Abstractions;
using CodeSense.Application.Commands.Users;
using CodeSense.Domain.Entities;
using CodeSense.Domain.Validators;
using FluentValidation;
using MediatR;

namespace CodeSense.Application.Handlers.Users.Commands
{
    public class CreateUserCommandHandler(IRepository<User> userService, IMapper mapper) : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IRepository<User> _userService = userService;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await Validate(user);

            user = await _userService.CreateAsync(user);

            return user.Id;
        }

        private async Task Validate(User user)
        {
            var checkExistence = await _userService.GetByEmailAsync(user.Email);

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
}