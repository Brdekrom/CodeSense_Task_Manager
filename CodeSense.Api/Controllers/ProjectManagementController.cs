using AutoMapper;
using CodeSense.Application.Abstractions;
using CodeSense.Domain.DTOs;
using CodeSense.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CodeSense.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectManagementController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IValidator<Project> _projectValidator;
    private readonly IMapper _mapper;

    public ProjectManagementController(
        IProjectService projectService,
        IValidator<Project> projectValidator,
        IMapper mapper)
    {
        _projectService = projectService;
        _projectValidator = projectValidator;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Post([FromBody] ProjectDTO dTO)
    {
        var project = _mapper.Map<Project>(dTO);
        var validationResult = _projectValidator.Validate(project);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        var selectedEmployees = _projectService.RetrieveAvailableEmployees(project.Requirements);

        if (selectedEmployees.Any())
        {
            return NotFound();
        }

        var employees = selectedEmployees
            .Select(_mapper.Map<EmployeeDTO>)
            .ToList();

        return Ok(employees);
    }
}