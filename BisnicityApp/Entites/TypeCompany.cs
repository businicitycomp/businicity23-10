using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
   public class TypeCompany
    {
        [Key]
        public int TypeCompanyID { get; set; }

        public string Typename { get; set; }
    }
}
