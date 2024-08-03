using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewApp1.Models
{
    public class AddEmployeeViewModel
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
        public int DepartmentID { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalaryValue { get; set; }

        // [ForeignKey("DepartmentID")]
        // public Department Department { get; set; }

        // public ICollection<Salary> SalaryValue { get; set; }
    }
}