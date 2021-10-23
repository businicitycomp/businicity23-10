using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
   public class Targetsector
    {
        [Key]
        public int TargetsectorID { get; set; }

        public string namesector { get; set; }
    }
}
