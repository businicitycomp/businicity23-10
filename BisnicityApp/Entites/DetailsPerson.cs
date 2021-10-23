using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
   public class DetailsPerson
    {
        [Key]
        public int DetailsPersonID { get; set; }
        [StringLength(90)]
        public string AboutUs { get; set; }
        [StringLength(90)]
        public string Expirence { get; set; }

        public string AboutImage { get; set; }

        public string Facebooklink { get; set; }

        public string Whatslink { get; set; }
       
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public virtual CatPerson CatPerson { get; set; }

       [ForeignKey("CatPersonID")]
        public int ? CatPersonID { get; set; }

    }
}
