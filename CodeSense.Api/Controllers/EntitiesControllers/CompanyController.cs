using CodeSense.Application.Handlers.Companies;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CodeSense.Api.Controllers.EntitiesManagement
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommand command)
        {
            try
            {
                var company = await _mediator.Send(command);

                return Ok(company);
            }
            catch (ValidationException validation)
            {
                return BadRequest(validation.ValidationResult.ErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCompany(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }
    }
}