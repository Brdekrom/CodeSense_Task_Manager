using AutoMapper;
using CodeSense.Domain.DTOs;
using CodeSense.Domain.Entities;

namespace CodeSense.Domain.Mappers;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<EmployeeDTO, Employee>();
    }
}