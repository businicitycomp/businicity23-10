using BisnicityApp.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class CompleteProfilePersonViewModels
    {
        public string PersonImagePath { get; set; }
        public string LinkedInLink { get; set; }

        public string Age { get; set; }

        public string GPA { get; set; }
        [Required]
        public string Major { get; set; }

        public string Address { get; set; }

        public IFormFile uploadpersonimage { get; set; }

        public IFormFile uploadscv { get; set; }

        public string pdfbath { get; set; }

        public int levelID { get; set; }
        public List<Educationlevel> Educationlevels { get; set; }
        public List<Univircity> univircitys { get; set; }
        public int uniID { get; set; }
    }
}
