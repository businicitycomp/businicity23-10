using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        public string PersonImage { get; set; }
       

        public string LinkedInLink { get; set; }

        public string Age { get; set; }

        public string GPA { get; set; }
        [Required]
        public string Major { get; set; }

        public string Address { get; set; }

        public string Cvpdf { get; set; }
        public int Flag { get; set; } = 0;
        public virtual Educationlevel Educationlevel { get; set; }

        [ForeignKey("EducationlevelID")]
        public int ? EducationlevelID { get; set; }

        public virtual Univircity Univircity { get; set; }

        [ForeignKey("UnivircityID")]
        public int? UnivircityID { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

    }
}
