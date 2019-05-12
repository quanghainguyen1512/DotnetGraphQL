using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetGraphQL.Core.Entities;
using DotnetGraphQL.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace DotnetGraphQL.Data.Repositories
{
    public class TaskRepository : BaseRepository<DotnetGraphQL.Core.Entities.Task, int>, ITaskRepository
    {
        public TaskRepository() { }
        public TaskRepository(Context ctx, ILogger<ITaskRepository> logger) : base(ctx, logger) { }

        public async Task<ICollection<Employee>> GetAssignedEmployees(int id)
        {
            var task = await Get(id, "Assignments.Employee");
            return task.Assignments.Select(a => a.Employee).ToList();
        }
    }
}