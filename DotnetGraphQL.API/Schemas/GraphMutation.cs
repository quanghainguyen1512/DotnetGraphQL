using DotnetGraphQL.API.Inputs;
using DotnetGraphQL.API.ObjectTypes;
using DotnetGraphQL.Core.Entities;
using DotnetGraphQL.Core.Interfaces;
using GraphQL.Types;

namespace DotnetGraphQL.API.Schemas
{
    public class GraphMutation : ObjectGraphType
    {
        public GraphMutation(IDepartmentRepository dep, IEmployeeRepository emp, ITaskRepository tas)
        {
            Field<EmployeeType>(
                "createEmp",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EmployeeInputType>> {Name = "emp"}
                ),
                resolve: ctx =>
                {
                    var newEmp = ctx.GetArgument<Employee>("emp");
                    return emp.Add(newEmp);
                }
            );

            // Field<TaskType>(
            //     "createTask",
            //     arguments: new QueryArguments(
            //         new QueryArgument<NonNullGraphType<TaskInputType>> {Name = "task"}
            //     ),
            //     resolve: ctx => 
            //     {
            //         var newTask = ctx.GetArgument<Task>("task");
            //         return tas.Add(newTask);
            //     }
            // );

            Field<DepartmentType>(
                "createDept",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<DepartmentInputType>> { Name = "newDept" }),
                resolve: ctx => 
                {
                    var res = dep.Add(ctx.GetArgument<Department>("newDept"));
                    dep.SaveChangesAsync();
                    return res;
                }
            );
        }
    }
}
