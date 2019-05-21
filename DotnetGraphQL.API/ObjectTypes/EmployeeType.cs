using System;
using DotnetGraphQL.Core.Entities;
using DotnetGraphQL.Core.Interfaces;
using GraphQL.Types;

namespace DotnetGraphQL.API.ObjectTypes
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType(IEmployeeRepository repo)
        {
            Name = "Employee";

            Field(x => x.Id);
            Field(x => x.Salary);
            Field(x => x.EmpName);
            Field<IntGraphType>("age", resolve: ctx => (new DateTime(1, 1, 1) + (DateTime.Now - ctx.Source.Dob)).Year - 1);
            Field<ListGraphType<TaskType>>("tasks", resolve: ctx => repo.GetTasks(ctx.Source.Id));
        }
    }
}