using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
    public class OurServices
    {
        [Key]
        [Required]
        public int OurServicesID { get; set; }
        
        public string AbuotServ { get; set; }
        
        public string AboutUs { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string LinkFace { get; set; }
        public string LinkTwet { get; set; }
        public string LinkInsta { get; set; }
        public string LinkWats { get; set; }
        public string GoogleMapLink { get; set; }

        public int CompanyNo { get; set; }

        public string DomainName { get; set; }

        public virtual Info Info { get; set; }


        [ForeignKey("UserId")]
        public string UserId { get; set; }

    }
}
