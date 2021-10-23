using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
    public  class DataPerson
    {
        [Key]
        public int DataPersonID { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        
        public string Email { get; set; }

        public string phoneeNo { get; set; }

        public virtual Gender Gender { get; set; }
        [ForeignKey("GenderID")]
        public int? GenderID { get; set; }

        public virtual Educationlevel Educationlevel { get; set; }

        [ForeignKey("EducationlevelID")]
        public int? EducationlevelID { get; set; }

        public virtual Univircity Univircity { get; set; }

        [ForeignKey("UnivircityID")]
        public int? UnivircityID { get; set; }


    }
}
