using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
  public  class volunteer
    {
        [Key]
        public int volunteerID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NationalID { get; set; }

        [Required]
        public string Major { get; set; }
        public string PhoneNo { get; set; }
        [Required]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}")]
        public DateTime BirthDay { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Descrption { get; set; }

        public virtual Gender Gender { get; set; }
        [ForeignKey("GenderID")]
        public int? GenderID { get; set; }
    }
}
