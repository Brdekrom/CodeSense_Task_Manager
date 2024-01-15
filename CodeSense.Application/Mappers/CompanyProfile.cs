using AutoMapper;
using CodeSense.Application.Commands.Company;

namespace CodeSense.Application.Mappers
{
    internal class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Domain.Entities.Company, CreateClientCompanyCommand>()
                .ReverseMap();
        }
    }
}