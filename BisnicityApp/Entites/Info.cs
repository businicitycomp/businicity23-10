using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
    public class Info
    { 
        [Key]
        public int InfoID { get; set; }
        [Required]
        public string CompanyName { get; set; }

        public string ImageProfile { get; set; }
        public int Flag { get; set; } = 0;


        public string  Linklinkedin { get; set; }
      
        [ForeignKey("UserId")]
        public string UserId { get; set; }

    }
}
