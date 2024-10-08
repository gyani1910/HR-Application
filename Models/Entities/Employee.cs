

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewApp1.Models.Entities;

namespace NewApp1.Models.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [ForeignKey("DepartmentID")]
        public int? DepartmentID { get; set; }
        public Department Department { get; set; }


        public ICollection<Salary> Salaries { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }
    }
}
