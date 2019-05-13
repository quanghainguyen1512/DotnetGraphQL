using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotnetGraphQL.Core.Interfaces;

namespace DotnetGraphQL.Core.Entities
{
    public class Task : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TaskName { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}