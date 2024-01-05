using CodeSense.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSense.Domain.Entities
{
    public class ClientCompany : EntityBase
    {
        public string Name { get; set; }
        public string PrimaryEmailAddress { get; set; }
        public ICollection<string>? SecondaryEmailAddresses { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<User> Users {  get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
