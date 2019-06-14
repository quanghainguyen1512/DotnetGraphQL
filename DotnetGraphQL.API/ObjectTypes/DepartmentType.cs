using DotnetGraphQL.Core.Entities;
using DotnetGraphQL.Core.Interfaces;
using GraphQL.Types;

namespace DotnetGraphQL.API.ObjectTypes
{
    public class DepartmentType : ObjectGraphType<Department>
    {
        public DepartmentType(IDepartmentRepository repo)
        {
            Field(x => x.Id);
            Field(x => x.DeptName);
            Field<ListGraphType<EmployeeType>>("employees",
            arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
            resolve: ctx => repo.GetEmployees(ctx.Source.Id), 
            description: "Department's employees");
        }
    }
}