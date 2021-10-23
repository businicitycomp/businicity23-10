using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
    public class CatTemp
   {
        [Key]
        
        public int CatTempID { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string url { get; set; }

        public string OnMonth { get; set; }
        public string SixMointh { get; set; }

        public string OnYears { get; set; }




    }
}
