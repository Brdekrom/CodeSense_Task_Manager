using AutoMapper;
using CodeSense.Domain.DTOs;
using CodeSense.Domain.Entities;

namespace CodeSense.Application.Mappers;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<EmployeeDTO, Employee>();
    }
}