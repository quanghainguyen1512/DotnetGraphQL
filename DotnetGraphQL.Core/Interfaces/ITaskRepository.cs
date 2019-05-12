using System.Collections.Generic;
using DotnetGraphQL.Core.Entities;

namespace DotnetGraphQL.Core.Interfaces
{
    public interface ITaskRepository : IBaseRepository<Task, int>
    {
        System.Threading.Tasks.Task<ICollection<Employee>> GetAssignedEmployees(int id); 
    }
}