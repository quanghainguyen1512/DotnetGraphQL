using DotnetGraphQL.API.ObjectTypes;
using DotnetGraphQL.Core.Interfaces;
using GraphQL.Types;

namespace DotnetGraphQL.API.Schemas
{
    public class GraphQuery : ObjectGraphType
    {
        public GraphQuery(IDepartmentRepository dep, IEmployeeRepository emp, ITaskRepository tas)
        {
            Field<ListGraphType<DepartmentType>>(
                "depts",
                resolve: ctx => dep.GetAll()
            );

            Field<DepartmentType>(
                "dept",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>{Name = "id"}),
                resolve: ctx => dep.Get(ctx.GetArgument<int>("id"))
            );
        }
    }
}