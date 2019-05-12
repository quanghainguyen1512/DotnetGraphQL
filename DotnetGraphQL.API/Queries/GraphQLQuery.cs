using System.Text;
using GraphQL.Types;
using Newtonsoft.Json.Linq;

namespace DotnetGraphQL.API.Queries
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}