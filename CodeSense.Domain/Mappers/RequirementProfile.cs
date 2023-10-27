using AutoMapper;
using CodeSense.Domain.DTOs;

namespace CodeSense.Domain.Mappers;

public class RequirementProfile : Profile
{
    public RequirementProfile()
    {
        CreateMap<RequirementProfile, RequirementDTO>();
        CreateMap<RequirementDTO, RequirementProfile>();
    }
}