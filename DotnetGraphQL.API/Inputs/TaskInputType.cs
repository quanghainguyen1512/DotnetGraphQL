using GraphQL.Types;

namespace DotnetGraphQL.API.Inputs
{
    public class TaskInputType : InputObjectGraphType
    {
        public TaskInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("taskName");
        }
    }
}