using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetGraphQL.Core.Entities;
using DotnetGraphQL.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace DotnetGraphQL.Data.Repositories
{
    public class DepartmentRepository : BaseRepository<Department, int>, IDepartmentRepository
    {
        public DepartmentRepository() { }
        public DepartmentRepository(Context ctx, ILogger<DepartmentRepository> logger) : base(ctx, logger) { }

        public async Task<ICollection<Employee>> GetEmployees(int id)
        {
            var dept = await Get(id, "Employees");
            return dept.Employees.Select(e => e).ToList();
        }
    }
}