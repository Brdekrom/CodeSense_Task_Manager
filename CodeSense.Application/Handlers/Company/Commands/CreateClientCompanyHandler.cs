using AutoMapper;
using CodeSense.Application.Abstractions;
using CodeSense.Application.Commands.Company;
using MediatR;

namespace CodeSense.Application.Handlers.Company.Commands
{
    public class CreateClientCompanyHandler(IRepository<Domain.Entities.Company> repository, IMapper mapper) : IRequestHandler<CreateClientCompanyCommand, int>
    {
        private readonly IRepository<Domain.Entities.Company> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(CreateClientCompanyCommand request, CancellationToken cancellationToken)
        {
            // TODO: add Validations

            var mappedCompany = _mapper.Map<Domain.Entities.Company>(request);

            var company = await _repository.CreateAsync(mappedCompany);

            return company.Id;
        }
    }
}