using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
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
    [Route("quote")]
    public async Task<IActionResult> PostAsync([FromBody] Project project)
    {
        try
        {
            var employees = await _projectService.HandleAsync(project);

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