using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
   public class Educationlevel
    {
        [Key]
        public int EducationlevelID { get; set; }

        public string levelName { get; set; }
    }
}
