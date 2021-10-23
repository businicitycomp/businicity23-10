using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
  public  class SkillsPerson
    {
        [Key]
        public int SkillsPersonID { get; set; }
        [Required]
        public string SkillsName { get; set; }

        public string Courses { get; set; }


        [ForeignKey("UserId")]
        public string UserId { get; set; }


    }
}
