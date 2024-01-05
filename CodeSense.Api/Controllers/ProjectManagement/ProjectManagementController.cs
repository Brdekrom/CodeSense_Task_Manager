using CodeSense.Application.Abstractions;
using CodeSense.Domain.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CodeSense.Api.Controllers.ProjectManagement;

[Route("api/[controller]")]
[ApiController]
public class ProjectManagementController(
    IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ProjectDTO dTO)
    {
        try
        {
            var employees = _projectService.Handle(dTO);

            return Ok(employees);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
        catch (NullReferenceException e)
        {
            return NotFound(e.Message);
        }
    }
}