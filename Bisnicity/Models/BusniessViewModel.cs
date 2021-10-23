using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class BusniessViewModel
    {
        [Required]
        public int InfoID { get; set; }
       
        [Required]
        [StringLength(265)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [StringLength(265)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 7)]

        public string Password { get; set; }
       
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]

        public string PhoneNo { get; set; }
        public string CompanyName { get; set; }

        public IFormFile ImageProfile { get; set; }

        public string detailspost { get; set; }
        public IFormFile postimage { get; set; }
        public string Tittelpost { get; set; }
        public string? pathimage { get; set; }
        public string Linklinkedin { get; set; }
    }
}
