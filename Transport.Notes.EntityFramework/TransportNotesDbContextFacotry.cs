using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Notes.EntityFramework
{
    public class TransportNotesDbContextFacotry : IDesignTimeDbContextFactory<TransportNotesDbContext>
    {
        public TransportNotesDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<TransportNotesDbContext>();
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TransportNotes;Trusted_Connection=True;");
            return new TransportNotesDbContext(options.Options);
        }
    }
}
