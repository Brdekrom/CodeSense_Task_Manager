using AutoMapper;
using CodeSense.Application.Abstractions;
using CodeSense.Application.Commands.Users;
using CodeSense.Domain.Entities;
using CodeSense.Domain.Validators;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSense.Application.Handlers.Users.Commands
{
    public class CreateUserCommandHandler() : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            Validate(user);

            var checkExistence = await _userService.GetUserByEmailAsync(user.Email);
            if (checkExistence is not null)
            {
                return false;
            }

            user = await _userService.CreateUserAsync(user);

            return user.Id != default;
        }

        private static void Validate(User user)
        {
            var validator = new UserValidator();
            var result = validator.Validate(user);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
