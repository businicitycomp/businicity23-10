using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
  public  class Idea
    {
        [Key]
        public int IdeaID { get; set; }

        [Required]
        public string ideaname { get; set; }

        [Required]
        public string descreption { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }

        public string phoneno { get; set; }

        public string Fileidea { get; set; }

        public virtual TypeIdea TypeIdea { get; set; }

        [ForeignKey("TypeIdeaID")]
        public int? TypeIdeaID { get; set; }
    }
}
