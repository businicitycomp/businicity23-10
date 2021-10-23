using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
   public class SupportedIdeas
    {

        [Key]
        public int SupportedIdeasID { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public virtual Idea Idea { get; set; }

        [ForeignKey("IdeaID")]
        public int? IdeaID { get; set; }
    }
}
