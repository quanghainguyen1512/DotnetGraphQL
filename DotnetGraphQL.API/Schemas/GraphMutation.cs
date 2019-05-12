using DotnetGraphQL.API.ObjectTypes;
using DotnetGraphQL.Core.Entities;
using DotnetGraphQL.Core.Interfaces;
using GraphQL.Types;

namespace DotnetGraphQL.API.Schemas
{
    public class GraphMutation : ObjectGraphType
    {
        // public GraphMutation(ContextServiceLocator locator)
        public GraphMutation(IDepartmentRepository dep, IEmployeeRepository emp, ITaskRepository tas)
        {
            Name = "CreateEmployee";

            Field<EmployeeType>(
                "createEmp",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EmployeeType>> {Name = "emp"}
                ),
                resolve: ctx =>
                {
                    var newEmp = ctx.GetArgument<Employee>("emp");
                    return emp.Add(newEmp);
                }
            );
        }
    }
}
