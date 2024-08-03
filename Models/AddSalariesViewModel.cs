using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewApp1.Models
{
    public class AddSalaryViewModel
    {

        [Required]
        public decimal SalaryValue { get; set; }
    }
}