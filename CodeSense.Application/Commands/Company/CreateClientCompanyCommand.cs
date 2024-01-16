using CodeSense.Application.DTOs;
using MediatR;

namespace CodeSense.Application.Commands.Company
{
    public class CreateClientCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public AddressDto Address { get; set; }
    }
}