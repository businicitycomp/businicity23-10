using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
   public class jobVacancy
    {
        [Key]
        public int jobVacancyID { get; set; }
        [Required]
        public string JobName { get; set; }

        public string Salary { get; set; }

        [Required]
        public string JobType { get; set; }

        [Required]
        [StringLength(90)]
        public string Requirements { get; set; }
        [StringLength(90)]
        public string Experience { get; set; }
        [Required]
        public string Email { get; set; }

        public string PhoneNo { get; set; }
        [Required]
        public string CompanyName { get; set; }

        public string LinkkedIn { get; set; }

        public string Address { get; set; }
        public string Pathpdf { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }





    }
}
