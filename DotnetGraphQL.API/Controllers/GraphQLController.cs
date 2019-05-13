using System;
using System.Threading.Tasks;
using DotnetGraphQL.API.Queries;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGraphQL.API.Controllers
{
    [Route("demo")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        
        public GraphQLController(ISchema schema, IDocumentExecuter executer)
        {
            _schema = schema;
            _documentExecuter = executer;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query is null) throw new ArgumentException(nameof(query));
            var inputs = query.Variables.ToInputs();
            var options = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documentExecuter.ExecuteAsync(options);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}