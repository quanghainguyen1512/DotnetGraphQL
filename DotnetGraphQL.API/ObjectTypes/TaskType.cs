using DotnetGraphQL.Core.Entities;
using DotnetGraphQL.Core.Interfaces;
using GraphQL.Types;

namespace DotnetGraphQL.API.ObjectTypes
{
    public class TaskType : ObjectGraphType<Task>
    {
        public TaskType(ITaskRepository repo)
        {
            Field(x => x.Id);
            Field(x => x.TaskName);
            Field<ListGraphType<EmployeeType>>("assignedEmps",
            arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
            resolve: ctx => repo.GetAssignedEmployees(ctx.Source.Id),
            description: "Assigned Employees");
        }
    }
}