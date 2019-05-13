using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetGraphQL.Core.Entities;
using DotnetGraphQL.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace DotnetGraphQL.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository() { }
        public EmployeeRepository(Context ctx, ILogger<IEmployeeRepository> logger) : base(ctx, logger) { }

        public async Task<ICollection<Core.Entities.Task>> GetTasks(int id)
        {
            var emp = await Get(id, "Assignments.AssignedTask");
            return emp.Assignments.Select(a => a.AssignedTask).ToList();
        }
    }
}