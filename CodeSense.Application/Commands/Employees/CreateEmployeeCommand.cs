using CodeSense.Domain.Common.Enum;
using CodeSense.Domain.Entities;
using CodeSense.Domain.ValueObjects;
using MediatR;

namespace CodeSense.Application.Commands.Employees
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public int EmployerCompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContactData ContactData { get; set; }
        public EmployeeLevel EmployeeLevel { get; set; }
    }
}