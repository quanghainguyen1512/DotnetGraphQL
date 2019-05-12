using GraphQL;
using GraphQL.Types;

namespace DotnetGraphQL.API.Schemas
{
    public class GraphSchema : Schema
    {
        public GraphSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<GraphQuery>();
            Mutation = resolver.Resolve<GraphMutation>();
        }
    }
}