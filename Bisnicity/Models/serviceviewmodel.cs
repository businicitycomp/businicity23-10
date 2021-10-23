using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class serviceviewmodel
    {
        public int ServiceID { get; set; }
        [Required]
        public string Servicename { get; set; }

        [Required]
        public string paragraph { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public IFormFile Image { get; set; }

        public string? userid { get; set; }
    }
}
