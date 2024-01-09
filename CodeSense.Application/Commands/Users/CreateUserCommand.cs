using MediatR;

namespace CodeSense.Application.Commands.Users
{
    public class CreateUserCommand : IRequest<int>
    {
        public string ClientCompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}