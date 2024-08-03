

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewApp1.Models.Entities;

namespace NewApp1.Models.Entities
{
    public class Salary
    {
        [Key]
        public int SalaryID { get; set; }

        [Required]
        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalaryValue { get; set; }
    }
}
