using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.EntityFramework
{
    public class TransportNotesDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public TransportNotesDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(a => a.Account)
                .WithMany(v => v.Vehciles);
            base.OnModelCreating(modelBuilder);
        }
    }
}
