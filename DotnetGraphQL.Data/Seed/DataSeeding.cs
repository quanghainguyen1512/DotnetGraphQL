using System;
using System.Collections.Generic;
using System.Linq;
using DotnetGraphQL.Core.Entities;
using Microsoft.Extensions.Logging;

namespace DotnetGraphQL.Data.Seed
{
    public static class DataSeeding
    {
        public static void EnsureSeedData(this Context ctx)
        {
            ctx.Logger.LogInformation("Seeding database");

            List<Department> depts = new List<Department>
            {
                new Department { DeptName = "R&D Squad" },
                new Department { DeptName = "Outsourcing"},
                new Department { DeptName = "Digital"}
            };

            if (!ctx.Departments.Any())
            {
                ctx.Logger.LogInformation("Seeding Departments");
                ctx.Departments.AddRange(depts);
                ctx.SaveChanges();
            }

            if (!ctx.Employees.Any())
            {
                ctx.Logger.LogInformation("Seeding Employees");
                var emps = new List<Employee>
                {
                    new Employee  { EmpName = "John Cena", Dob = new DateTime(1990, 1, 1), Salary = 2000 }
                };
            }
        }
    }
}