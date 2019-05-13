using Microsoft.EntityFrameworkCore;
using DotnetGraphQL.Core.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DotnetGraphQL.Data
{
    public class Context : DbContext
    {
        public readonly ILogger Logger;
        // private bool _migrations; 

        public Context()
        {
            // _migrations = true;
        }

        public Context(DbContextOptions options, ILogger<Context> logger) : base(options) 
        {
            Logger = logger;
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>().HasKey(a => new { a.EmployeeId, a.TaskId });
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
    }
}