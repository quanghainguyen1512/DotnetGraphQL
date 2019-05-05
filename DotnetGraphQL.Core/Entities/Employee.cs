using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using DotnetGraphQL.Core.Interfaces;

namespace DotnetGraphQL.Core.Entities
{
    public class Employee : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string EmpName { get; set; }
        public DateTime Dob { get; set; }
        public int Salary { get; set; }
        public Department Department { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}