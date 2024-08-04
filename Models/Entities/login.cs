using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewApp1.Models.Entities;

namespace NewApp1.Models.Entities

{
    public class Login
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
