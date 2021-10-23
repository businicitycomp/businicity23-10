using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
   public class yourstatus
    {
        [Key]
        public int yourstatusID { get; set; }

        public string NameStatus { get; set; }
    }
}
