using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
   public class CareerPath
    {
        [Key]
        public int CareerPathID { get; set; }

        public string NameCareer { get; set; }
    }
}
