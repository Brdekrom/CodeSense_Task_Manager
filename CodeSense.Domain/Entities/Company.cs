using CodeSense.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSense.Domain.Entities
{
    public class Company : EntityBase
    {
        public string Name { get; set; }
        public string PrimaryEmail { get; set; }
        public ICollection<string>? SecondaryEmails { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public ICollection<string> SecondaryPhoneNumbers { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<User> Users {  get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
