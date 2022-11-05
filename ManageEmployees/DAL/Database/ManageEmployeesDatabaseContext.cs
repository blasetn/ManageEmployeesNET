using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Database
{
    public class ManageEmployeesDatabaseContext : DbContext
    {
        public ManageEmployeesDatabaseContext(DbContextOptions<ManageEmployeesDatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<Employees> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API in config file

            modelBuilder.Entity<Employees>().HasIndex(e => new { e.Email}).IsUnique(true);
            modelBuilder.Entity<Employees>().HasIndex(e => new { e.Phone}).IsUnique(true);

            // Seed Data
            modelBuilder.Seeding();
        }
    }
}
