using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
   public class ContactUs
    {
        [Key]
        public int ContactUsID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Messsage { get; set; }

    }
}
