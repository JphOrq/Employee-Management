using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.Models
{
    public class NewEmployeeDB : DbContext
    {
        public NewEmployeeDB(DbContextOptions<NewEmployeeDB> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}