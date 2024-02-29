using CodeSense.Domain.Abstractions;

namespace CodeSense.Domain.Entities;

public class ProjectQuote(Project project, int consultancyId, int clientCompanyId) : EntityBase
{
    public int ConsultancyId { get; private set; } = consultancyId;
    public int ClientCompanyId { get; private set; } = clientCompanyId;
    public bool IsAccepted { get; private set; } = false;
    public bool IsDue { get => IsAccepted || CreatedAt.AddHours(48) < DateTime.Now; }
    public Project Project { get; } = project;

    public ProjectQuote() : this(new Project(), 0, 0)
    {
    }

    public void AcceptQuote()
    {
        IsAccepted = true;
    }
}