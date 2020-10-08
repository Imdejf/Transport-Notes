using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Notes.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
    }
}
