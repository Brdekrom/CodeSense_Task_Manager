using AutoMapper;
using CodeSense.Domain.DTOs;
using CodeSense.Domain.Entities;

namespace CodeSense.Domain.Mappers;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDTO>()
            .ForMember(dest => dest.Requirements, opt => opt.MapFrom(src => src.Requirements))
            .ReverseMap();
    }
}