using GraphQL.Types;

namespace DotnetGraphQL.API.Inputs
{
    public class EmployeeInputType : InputObjectGraphType
    {
        public EmployeeInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("empName");
            Field<NonNullGraphType<DateGraphType>>("dob");
            Field<IntGraphType>("salary");
            // Field<DepartmentInputType>("");
        }
    }
}