using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
using CodeSense.Domain.ValueObjects;
using MediatR;

namespace CodeSense.Application.Handlers.Companies;

public class CreateCompanyCommand : IRequest<Company>
{
    public string VatNumber { get; set; }
    public string Name { get; set; }
    public ContactData ContactData { get; set; }
    public Address Address { get; set; }
    public bool IsClient { get; set; }
}

public class CreateCompanyHandler(IRepository<Company> repository) : IRequestHandler<CreateCompanyCommand, Company>
{
    private readonly IRepository<Company> _repository = repository;

    public async Task<Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var mappedCompany = new Company(request.VatNumber, request.Name, request.ContactData, request.Address, request.IsClient);

        var company = await _repository.CreateAsync(mappedCompany);

        return company;
    }
}