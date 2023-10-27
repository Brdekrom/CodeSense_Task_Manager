using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSense.Domain.Entities
{
    public class Task
    {
        public string Title { get; set; }
        public int Profit { get; set; }
        public DateOnly Deadline { get; set; }
        public List<Requirement> Requirements { get; set; }
    }
}
