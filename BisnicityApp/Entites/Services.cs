using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
    public class Services
    {
        [Key]
        [Required]
        public int ServicesID { get; set; }
        [Required]
        public string Servicename { get; set; }
        [Required]
        public string  paragraph { get; set; }
     
        public string Image { get; set; }

        public virtual Info Info { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
    }
}
