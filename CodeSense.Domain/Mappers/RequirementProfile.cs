﻿using AutoMapper;
using CodeSense.Domain.DTOs;
using CodeSense.Domain.Entities;

namespace CodeSense.Domain.Mappers;

public class RequirementProfile : Profile
{
    public RequirementProfile()
    {
        CreateMap<Requirement, RequirementDTO>()
            .ReverseMap();
    }
}