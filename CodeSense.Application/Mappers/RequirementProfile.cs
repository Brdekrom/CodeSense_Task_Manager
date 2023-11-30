using AutoMapper;
using CodeSense.Domain.DTOs;
using CodeSense.Domain.Entities;

namespace CodeSense.Application.Mappers;

public class RequirementProfile : Profile
{
    public RequirementProfile()
    {
        CreateMap<Requirement, RequirementDTO>()
            .ReverseMap();
    }
}