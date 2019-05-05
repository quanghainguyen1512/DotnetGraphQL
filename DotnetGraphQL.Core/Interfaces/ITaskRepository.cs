using System.Collections.Generic;
using DotnetGraphQL.Core.Entities;

namespace DotnetGraphQL.Core.Interfaces
{
    public interface ITaskRepository : IBaseRepository<Task, int>
    {
        List<System.Threading.Tasks.Task<Employee>> GetAssignedEmployees(int id); 
    }
}