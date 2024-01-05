using AutoMapper;
using CodeSense.Application.Abstractions;
using CodeSense.Domain.DTOs;
using CodeSense.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeSense.Api.Controllers.EntitiesManagement;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeeController : ControllerBase
{
    private readonly IEntityManagementService<Employee> _employeeService;
    private readonly IValidator<Employee> _employeeValidator;
    private readonly IMapper _mapper;

    public EmployeeController(
        IEntityManagementService<Employee> employeeService,
        IValidator<Employee> employeeValidator,
        IMapper mapper)
    {
        _employeeService = employeeService;
        _employeeValidator = employeeValidator;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateEmployee([FromBody] EmployeeDTO dTO)
    {
        var employee = _mapper.Map<Employee>(dTO);

        var validationResult = _employeeValidator.Validate(employee);

        if (!validationResult.IsValid)
            return BadRequest(ModelState);

        var createdEmployee = _employeeService.Create(employee);

        return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
    }

    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var project = _employeeService.GetAll()
            .Select(_mapper.Map<Employee>)
            .ToList();

        return Ok(project);
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById(int id)
    {
        var employee = _employeeService.GetById(id);
        if (employee is null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<EmployeeDTO>(employee));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, [FromBody] EmployeeDTO dTO)
    {
        var employee = _mapper.Map<Employee>(dTO);

        if (id != employee.Id)
        {
            return BadRequest("Employee ID mismatch.");
        }

        var validationResult = _employeeValidator.Validate(employee);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var updatedEmployee = _employeeService.Update(employee);

        if (updatedEmployee is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<EmployeeDTO>(updatedEmployee));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = _employeeService.GetById(id);
        if (employee is null)
        {
            return NotFound();
        }

        _employeeService.Delete(id);
        return NoContent();
    }
}