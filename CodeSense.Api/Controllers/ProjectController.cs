using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeSense.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    public IActionResult CreateProject([FromBody] Project newProject)
    {
        if (ModelState.IsValid)
        {
            var createdProject = _projectService.CreateProject(newProject);
            return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.Id }, createdProject);
        }
        return BadRequest(ModelState);
    }

    [HttpGet]
    public IActionResult GetAllProjects()
    {
        return Ok(_projectService.GetAllProjects());
    }

    [HttpGet("{id}")]
    public IActionResult GetProjectById(int id)
    {
        var project = _projectService.GetProjectById(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProject(int id, [FromBody] Project updatedProject)
    {
        if (id != updatedProject.Id)
        {
            return BadRequest("Project ID mismatch.");
        }

        var project = _projectService.UpdateProject(updatedProject);

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProject(int id)
    {
        var project = _projectService.GetProjectById(id);
        if (project == null)
        {
            return NotFound();
        }

        _projectService.DeleteProject(id);
        return NoContent();
    }

}

