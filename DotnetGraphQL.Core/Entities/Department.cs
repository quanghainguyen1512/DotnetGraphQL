using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DotnetGraphQL.Core.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string DeptName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}