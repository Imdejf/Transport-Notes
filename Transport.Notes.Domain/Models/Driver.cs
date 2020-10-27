using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Notes.Domain.Models
{
    public class Driver : DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
        public DateTime EmploymentDay { get; set; }
    }
}
