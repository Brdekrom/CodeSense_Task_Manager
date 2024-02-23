using AutoMapper;
using CodeSense.Domain.DTOs;
using CodeSense.Domain.ValueObjects;

namespace CodeSense.Application.Mappers;

public class RequirementProfile : Profile
{
    public RequirementProfile()
    {
        CreateMap<Requirement, RequirementDTO>()
            .ReverseMap();
    }
}