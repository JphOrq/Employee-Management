using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 6,
                    FirstName = "Jose",
                    MiddleName = "Cali",
                    LastName = "Orqu",
                    Address = "B7 L8 Espina St., Caloocan City",
                    BirthDate = new DateTime(2008, 01, 20),
                    Email = "joseph_orquita@yahoo.com",
                    Department = Dept.Accounting,
                    Salary = 30000
                }
            );
        }
    }
}