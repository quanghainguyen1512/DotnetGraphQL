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

            var depts = new List<Department>
            {
                new Department { DeptName = "R&D Squad" },
                new Department { DeptName = "Outsourcing"},
                new Department { DeptName = "Freelance"}
            };

            if (!ctx.Departments.Any())
            {
                ctx.Logger.LogInformation("Seeding Departments");
                ctx.Departments.AddRange(depts);
                ctx.SaveChanges();
            }

            var tasks = new List<Task>
            {
                new Task { TaskName = "Deploy service" },
                new Task { TaskName = "Building GUI" },
                new Task { TaskName = "Training model" },
                new Task { TaskName = "Testing feature" },
                new Task { TaskName = "Research framework" },
            };

            if (!ctx.Tasks.Any())
            {
                ctx.Logger.LogInformation("Seeding Tasks");
                ctx.Tasks.AddRange(tasks);
                ctx.SaveChanges();
            }

            if (!ctx.Employees.Any())
            {
                ctx.Logger.LogInformation("Seeding Employees");
                var emps = new List<Employee>
                {
                    new Employee
                    {
                        EmpName = "Black Widow",
                        Dob = new DateTime(1990, 1, 1),
                        Salary = 2000, Department = depts[0],
                        Assignments = new List<Assignment>
                        {
                            new Assignment { AssignedTask = tasks[0] },
                            new Assignment { AssignedTask = tasks[2] },
                            new Assignment { AssignedTask = tasks[1] },
                        }
                    },
                    new Employee
                    {
                        EmpName = "Thor Odinson",
                        Dob = new DateTime(1991, 6, 22),
                        Salary = 1500, Department = depts[2],
                        Assignments = new List<Assignment>
                        {
                            new Assignment { AssignedTask = tasks[2] },
                            new Assignment { AssignedTask = tasks[3] },
                            new Assignment { AssignedTask = tasks[4] },
                        }
                    },
                    new Employee
                    {
                        EmpName = "Iron Man",
                        Dob = new DateTime(1993, 2, 1),
                        Salary = 1200,
                        Department = depts[1],
                        Assignments = new List<Assignment>
                        {
                            new Assignment { AssignedTask = tasks[0] },
                            new Assignment { AssignedTask = tasks[1] },
                            new Assignment { AssignedTask = tasks[4] }
                        }
                    },
                    new Employee
                    {
                        EmpName = "Cap America",
                        Dob = new DateTime(1991, 9, 29),
                        Salary = 2200, Department = depts[1],
                        Assignments = new List<Assignment>
                        {
                            new Assignment { AssignedTask = tasks[2] },
                            new Assignment { AssignedTask = tasks[3] }
                        }
                    },
                    new Employee
                    { 
                        EmpName = "Rocket Racoon",
                        Dob = new DateTime(1986, 3, 21),
                        Salary = 1100,
                        Department = depts[0],
                        Assignments = new List<Assignment>
                        {
                            new Assignment { AssignedTask = tasks[3] },
                            new Assignment { AssignedTask = tasks[4] }
                        }
                    },
                    new Employee
                    { 
                        EmpName = "Hawk Eye",
                        Dob = new DateTime(1985, 4, 14),
                        Salary = 2000,
                        Department = depts[0],
                        Assignments = new List<Assignment>
                        {
                            new Assignment { AssignedTask = tasks[1] }
                        }
                    },
                    new Employee
                    { 
                        EmpName = "The Hulk",
                        Dob = new DateTime(1979, 5, 9),
                        Salary = 1900,
                        Department = depts[2],
                        Assignments = new List<Assignment>
                        {
                            new Assignment { AssignedTask = tasks[3] },
                            new Assignment { AssignedTask = tasks[2] }
                        }
                    },
                    new Employee
                    { 
                        EmpName = "Ant-man",
                        Dob = new DateTime(1988, 7, 3),
                        Salary = 1500,
                        Department = depts[1],
                        Assignments = new List<Assignment>
                        {
                            new Assignment { AssignedTask = tasks[3] },
                            new Assignment { AssignedTask = tasks[4] }
                        }
                    }
                };
                ctx.Employees.AddRange(emps);
                ctx.SaveChanges();
            }
        }
    }
}