using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
using MediatR;

namespace CodeSense.Application.Handlers.Projects;

public class AcceptProjectCommand : IRequest
{
    public int ClientCompanyId { get; set; }
    public Project Project { get; set; }
}

public class AcceptProjectHandler(IRepository<Company> companyRepository) : IRequestHandler<AcceptProjectCommand>
{
    private readonly IRepository<Company> _companyRepository = companyRepository;

    public async Task Handle(AcceptProjectCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.ClientCompanyId);
        var clientCompany = await _companyRepository.GetByIdAsync(request.ClientCompanyId);
        if (clientCompany is null)
        {
            throw new NullReferenceException("Client Company not found");
        }
        company.ProjectQuotes!.First(pq => pq.Project.Id == request.Project.Id).AcceptQuote();

        clientCompany.AddProject(request.Project);

        await _companyRepository.UpdateAsync(clientCompany);
        await _companyRepository.UpdateAsync(company);

        await _companyRepository.SaveChanges();
    }
}