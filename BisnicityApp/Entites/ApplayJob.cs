using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
  public  class ApplayJob
    {
        [Key]
        public int ApplayJobID { get; set; }
        public virtual jobVacancy JobVacancy { get; set; }

        [ForeignKey("JobVacancyID")]

        public int ? JobVacancyID { get; set; }


        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [ForeignKey("UserbusID")]
        public string UserbusID { get; set; }

    }
}
