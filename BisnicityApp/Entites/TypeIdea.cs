using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
    public class TypeIdea
    {
        [Key]
        public int TypeIdeaID { get; set; }
        public string NameType { get; set; }
    }
}
