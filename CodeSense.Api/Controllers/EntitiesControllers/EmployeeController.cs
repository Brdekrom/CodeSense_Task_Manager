using AutoMapper;
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
    private readonly IValidator<Employee> _employeeValidator;
    private readonly IMapper _mapper;

    public EmployeeController(
        IValidator<Employee> employeeValidator,
        IMapper mapper)
    {
        _employeeValidator = employeeValidator;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateEmployee([FromBody] EmployeeDTO dTO)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, [FromBody] EmployeeDTO dTO)
    {
        //var employee = _mapper.Map<Employee>(dTO);

        //if (id != employee.Id)
        //{
        //    return BadRequest("Employee ID mismatch.");
        //}

        //var validationResult = _employeeValidator.Validate(employee);

        //if (!validationResult.IsValid)
        //    return BadRequest(validationResult.Errors);

        //var updatedEmployee = _employeeService.Update(employee);

        //if (updatedEmployee is null)
        //{
        //    return NotFound();
        //}

        //return Ok(_mapper.Map<EmployeeDTO>(updatedEmployee));

        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        //var employee = _employeeService.GetById(id);
        //if (employee is null)
        //{
        //    return NotFound();
        //}

        //_employeeService.Delete(id);
        //return NoContent();

        throw new NotImplementedException();
    }
}