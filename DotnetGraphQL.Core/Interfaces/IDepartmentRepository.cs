using System.Collections.Generic;
using DotnetGraphQL.Core.Entities;

namespace DotnetGraphQL.Core.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department, int>
    {
        System.Threading.Tasks.Task<ICollection<Employee>> GetEmployees(int id);
    }
}