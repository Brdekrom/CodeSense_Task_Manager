using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
using CodeSense.Domain.ValueObjects;
using MediatR;

namespace CodeSense.Application.Handlers.Projects;

public class QuoteProjectCommand : IRequest<Project>
{
    public int CompanyId { get; set; }
    public int ClientCompanyId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ProjectDates ProjectDates { get; set; }
    public FinancialData FinancialData { get; set; }
    public ICollection<Requirement>? Requirements { get; set; }
}

public class QuoteProjectHandler(IProjectService projectService, IRepository<Company> repository) : IRequestHandler<QuoteProjectCommand, Project>
{
    private readonly IProjectService _projectService = projectService;
    private readonly IRepository<Company> _companyRepository = repository;

    public async Task<Project> Handle(QuoteProjectCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.CompanyId);

        var project = new Project(request.Name, company, request.ProjectDates);

        project.SetDescription(request.Description ?? string.Empty);
        project.SetFinancialData(request.FinancialData);

        if (request.Requirements is null)
        {
            throw new NullReferenceException("No Requirements available for this project");
        }

        foreach (var requirement in request.Requirements)
        {
            project.AddRequirement(requirement);
        }

        var quotedProject = await _projectService.HandleAsync(project);

        company.AddQuote(new ProjectQuote(quotedProject, company.Id, request.ClientCompanyId));

        await _companyRepository.UpdateAsync(company);
        await _companyRepository.SaveChanges();

        return quotedProject;
    }
}