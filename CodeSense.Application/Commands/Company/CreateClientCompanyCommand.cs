using CodeSense.Domain.ValueObjects;
using MediatR;

namespace CodeSense.Application.Commands.Company
{
    public class CreateClientCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public ContactData ContactData { get; set; }
        public Address Address { get; set; }
    }
}