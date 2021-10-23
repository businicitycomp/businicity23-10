using BisnicityApp.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class volunteerViewModel
    {
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

        public int genderID { get; set; }
        public List<Gender> Genders { get; set; }

    }
}
