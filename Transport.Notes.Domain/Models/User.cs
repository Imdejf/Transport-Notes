using System;
using System.Collections.Generic;

namespace Transport.Notes.Domain.Models
{
    public class User : DomainObject
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateJoined { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
