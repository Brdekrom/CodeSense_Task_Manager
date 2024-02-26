using CodeSense.Application.Handlers.Projects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSense.Api.Controllers.EntitiesManagement;

[ApiController]
[Route("api/[controller]")]
public class ProjectController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [Route("quote")]
    public async Task<IActionResult> QuoteProject([FromBody] QuoteProjectCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetProject(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateProject(int id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{id}/requirements")]
    public async Task<IActionResult> GetProjectRequirements(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{id}/employees")]
    public async Task<IActionResult> GetProjectEmployees(int id)
    {
        throw new NotImplementedException();
    }
}