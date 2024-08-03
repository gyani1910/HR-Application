

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewApp1.Models.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
