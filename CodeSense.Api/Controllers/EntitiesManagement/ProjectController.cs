using Microsoft.AspNetCore.Mvc;

namespace CodeSense.Api.Controllers.EntitiesManagement;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    // This is commented out because it will be refactored soon.

    //private readonly IValidator<Project> _projectValidator;
    //private readonly IMapper _mapper;

    //public ProjectController(
    //    IValidator<Project> projectValidator,
    //    IMapper mapper)
    //{
    //    _projectValidator = projectValidator;
    //    _mapper = mapper;
    //}

    //[HttpPost]
    //public IActionResult CreateProject([FromBody] ProjectDTO dTO)
    //{
    //    var project = _mapper.Map<Project>(dTO);

    //    var validationResult = _projectValidator.Validate(project);
    //    if (!validationResult.IsValid)
    //    {
    //        return BadRequest(validationResult.Errors);
    //    }

    //    var createdProject = _projectService.Create(project);
    //    return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.Id }, _mapper.Map<ProjectDTO>(createdProject));
    //}

    //[HttpGet]
    //public IActionResult GetAllProjects()
    //{
    //    var projects = _projectService.GetAll()
    //        .Select(_mapper.Map<ProjectDTO>)
    //        .ToList();

    //    return Ok(projects);
    //}

    //[HttpGet("{id}")]
    //public IActionResult GetProjectById(int id)
    //{
    //    var project = _projectService.GetById(id);
    //    if (project is null)
    //    {
    //        return NotFound();
    //    }
    //    return Ok(_mapper.Map<ProjectDTO>(project));
    //}

    //[HttpPut("{id}")]
    //public IActionResult UpdateProject(int id, [FromBody] ProjectDTO dTO)
    //{
    //    var project = _mapper.Map<Project>(dTO);
    //    if (id != project.Id)
    //    {
    //        return BadRequest("Project ID mismatch.");
    //    }

    //    var validationResult = _projectValidator.Validate(project);

    //    if (!validationResult.IsValid)
    //        return BadRequest(ModelState);

    //    var updatedProject = _projectService.Update(project);

    //    if (updatedProject is null)
    //    {
    //        return NotFound();
    //    }

    //    return Ok(_mapper.Map<ProjectDTO>(updatedProject));
    //}

    //[HttpDelete("{id}")]
    //public IActionResult DeleteProject(int id)
    //{
    //    var project = _projectService.GetById(id);
    //    if (project is null)
    //    {
    //        return NotFound();
    //    }

    //    _projectService.Delete(id);
    //    return NoContent();
    //}
}