using System.ComponentModel.DataAnnotations;

namespace DotnetGraphQL.Core.Entities
{
    public class Assignment
    {
        public int EmpId { get; set; }
        public Employee Employee { get; set; }
        public int TaskId { get; set; }
        public Task AssignedTask { get; set; }
    }
}