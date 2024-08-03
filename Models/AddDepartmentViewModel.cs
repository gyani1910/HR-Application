using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewApp1.Models
{
    public class AddDepartmentViewModel
    {

        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; }
    }
}