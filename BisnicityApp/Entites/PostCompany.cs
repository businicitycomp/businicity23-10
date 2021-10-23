using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
  public  class PostCompany
    {
        [Key]
        public int PostCompanyID { get; set; }
        [Required]
        public string TitelePost { get; set; }
        public string DetailsPost { get; set; }

        public string ImagePost { get; set; }


        [ForeignKey("UserId")]
        public string UserId { get; set; }
    }
}
