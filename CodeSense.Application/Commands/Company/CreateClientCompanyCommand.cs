using CodeSense.Domain.Entities;
using MediatR;

namespace CodeSense.Application.Commands.Company
{
    public class CreateClientCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}