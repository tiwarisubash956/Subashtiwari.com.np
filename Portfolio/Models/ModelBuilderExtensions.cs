using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Sagar Soni",
                    Department = Department.Microsoft,
                    Email = "sagar.so@cisinlabs.com",
                    Designation = "Intern"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Kuldeep Singh Chouhan",
                    Department = Department.Microsoft,
                    Email = "kuldeep.si@cisinlabs.com",
                    Designation = "Intern"
                });
        }
    }
}
