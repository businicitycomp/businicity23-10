using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class CompleteprofileBusniscssViewModel
    {
        public string CompanyName { get; set; }
        [Required]
        public IFormFile ImageProfile { get; set; }

        public string Linklinkedin { get; set; }
    }
}
