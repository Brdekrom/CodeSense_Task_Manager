using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSense.Domain.Entities
{
    public class Employee
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public int Cost { get; set; }
        public DateOnly AvailableFrom { get; set; }
        public DateOnly AvailableUntil { get; set; }
    }
}
