using System.Collections.Generic;
using DotnetGraphQL.Core.Entities;

namespace DotnetGraphQL.Core.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee, int>
    {
        System.Threading.Tasks.Task<ICollection<Task>> GetTasks(int id);
    }
}