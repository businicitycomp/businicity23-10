using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class Changepasswordviewmodel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Current Password")]
        public string Currntpassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string sPassword { get; set; } 
        [DataType(DataType.Password)]
        [Compare(nameof(sPassword), ErrorMessage = BisnicityKey.ConfirmPassword)]
        [Display(Name = "Confirm Password")]
        public string sConfirmPassword { get; set; } 

    }
}
