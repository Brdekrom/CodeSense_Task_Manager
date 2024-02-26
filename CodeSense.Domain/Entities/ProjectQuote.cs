using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class ProjectQuote(Project project, int companyId, int clientCompanyId) : EntityBase
{
    public int CompanyId { get; private set; } = companyId;
    public int ClientCompanyId { get; private set; } = clientCompanyId;
    public bool IsAccepted { get; private set; } = false;
    public Project Project { get; } = project;

    public void AcceptQuote()
    {
        IsAccepted = true;
    }
}