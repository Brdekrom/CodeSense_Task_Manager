using CodeSense.Application.Abstractions;
using CodeSense.Application.Commands.Company;
using CodeSense.Domain.ValueObjects;
using MediatR;

namespace CodeSense.Application.Handlers.Company.Commands
{
    public class CreateClientCompanyHandler(IRepository<Domain.Entities.Company> repository) : IRequestHandler<CreateClientCompanyCommand, int>
    {
        private readonly IRepository<Domain.Entities.Company> _repository = repository;

        public async Task<int> Handle(CreateClientCompanyCommand request, CancellationToken cancellationToken)
        {
            // TODO: add Validations
            var mappedAddress = new Domain.Entities.Address
            {
                Street = request.Address.Street,
                City = request.Address.City,
                State = request.Address.State,
                ZipCode = request.Address.ZipCode,
                Country = request.Address.Country,
            };

            var mappedCompany = new Domain.Entities.Company
            {
                Name = request.Name,
                PrimaryEmail = request.PrimaryEmail,
                PrimaryPhoneNumber = request.PrimaryPhoneNumber,
                Addresses = new List<Address> { mappedAddress }
            };

            var company = await _repository.CreateAsync(mappedCompany);

            return company.Id;
        }
    }
}