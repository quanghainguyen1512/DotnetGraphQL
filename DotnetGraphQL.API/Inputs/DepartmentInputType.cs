using GraphQL.Types;

namespace DotnetGraphQL.API.Inputs
{
    public class DepartmentInputType : InputObjectGraphType
    {
        public DepartmentInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("deptName");
        }
    }
}