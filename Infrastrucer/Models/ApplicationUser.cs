using BisnicityApp.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Models
{
   public class ApplicationUser :IdentityUser
   {
        #region Properties
        [Required]
        public string sFirstname { get; set; }
        [Required]
        public string sLastname { get; set; }
   
        public virtual Gender Gender { get; set; }
        [ForeignKey("GenderID")]
        public int? GenderID { get; set; }
        #endregion
    }
}