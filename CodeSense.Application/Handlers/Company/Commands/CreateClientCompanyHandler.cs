using CodeSense.Application.Abstractions;
using CodeSense.Application.Commands.Company;
using MediatR;

namespace CodeSense.Application.Handlers.Company.Commands
{
    public class CreateClientCompanyHandler(IRepository<Domain.Entities.Company> repository) : IRequestHandler<CreateClientCompanyCommand, int>
    {
        private readonly IRepository<Domain.Entities.Company> _repository = repository;

        public async Task<int> Handle(CreateClientCompanyCommand request, CancellationToken cancellationToken)
        {
            var mappedCompany = new Domain.Entities.Company(request.Name, request.ContactData, request.Address);

            var company = await _repository.CreateAsync(mappedCompany);

            return company.Id;
        }
    }
}