using CodeSense.Application.Commands.Company;
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
        public async Task<IActionResult> CreateClientCompany(CreateClientCompanyCommand command)
        {
            try
            {
                var companyId = await _mediator.Send(command);

                return Ok(companyId);
            }
            catch (ValidationException validation)
            {
                return BadRequest(validation.ValidationResult.ErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetClientCompanies()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetClientCompany(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateClientCompany(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteClientCompany(int id)
        {
            throw new NotImplementedException();
        }
    }
}