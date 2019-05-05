using Microsoft.EntityFrameworkCore;
using DotnetGraphQL.Core.Entities;
using Microsoft.Extensions.Logging;

namespace DotnetGraphQL.Data
{
    public class Context : DbContext
    {
        public readonly ILogger Logger;
        private bool _migrations; 

        public Context()
        {
            _migrations = true;
        }

        public Context(DbContextOptions options, ILogger<Context> logger) : base(options) 
        {
            Logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (_migrations)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=emapi;User Id=SA;Password=Haideptrai1;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>().HasKey(a => new { a.EmpId, a.TaskId });
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
    }
}