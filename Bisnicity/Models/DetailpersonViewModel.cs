using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class DetailpersonViewModel
    {
        [Required]
        public string AboutUs { get; set; }


        public string Expirence { get; set; }

        public string AboutImage { get; set; }

        public string Facebooklink { get; set; }

        public string Whatslink { get; set; }

        public int CatPersonID { get; set; }

        public int personID { get; set; }
        public IFormFile ? File { get; set; }
    }
}
