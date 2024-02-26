﻿using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
using MediatR;

namespace CodeSense.Application.Handlers.Projects;

public class AcceptProjectCommand : IRequest
{
    public int ConsultancyId { get; set; }
    public int ClientCompanyId { get; set; }
    public Guid QuoteId { get; set; }
    public Project Project { get; set; }
}

public class AcceptProjectHandler(IRepository<Company> companyRepository) : IRequestHandler<AcceptProjectCommand>
{
    private readonly IRepository<Company> _companyRepository = companyRepository;

    public async Task Handle(AcceptProjectCommand request, CancellationToken cancellationToken)
    {
        var consultancy = await _companyRepository.GetByIdAsync(request.ConsultancyId);
        var clientCompany = await _companyRepository.GetByIdAsync(request.ClientCompanyId);
        if (clientCompany is null)
        {
            throw new NullReferenceException("Client Company not found");
        }

        if (consultancy.IsClient || !clientCompany.IsClient)
        {
            throw new NullReferenceException(clientCompany.IsClient ? "Consultancy is a client" : "Client Company is not a client");
        }

        consultancy.QuoteAccepted(request.QuoteId);
        consultancy.AddProject(request.Project);

        clientCompany.AddProject(request.Project);

        await _companyRepository.UpdateAsync(clientCompany);
        await _companyRepository.UpdateAsync(consultancy);

        await _companyRepository.SaveChanges();
    }
}