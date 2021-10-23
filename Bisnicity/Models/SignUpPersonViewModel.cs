using BisnicityApp.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class SignUpPersonViewModel
    {
        [Required]
        public int PersonID { get; set; }

        public string PersonImagePath { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string SecoundName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 7)]
        public string Password { get; set; }

        public string LinkedInLink { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string phoneNo { get; set; }

        public string Age { get; set; }

        public string GPA { get; set; }
        [Required]
        public string Major { get; set; }

        public string Address { get; set; }

        public IFormFile uploadpersonimage { get; set; }
       
        public IFormFile uploadscv { get; set; }

        public string pdfbath { get; set; }

        public int levelID { get; set; }
        public int genderID { get; set; }

        public List<Educationlevel> Educationlevels { get; set; }

        public List<Gender> Genders { get; set; }
        public List<Univircity> univircitys { get; set; }

        public int uniID { get; set; }
        public DateTime CreatedAtPerson { get; set; } = DateTime.Now;
    }
}
