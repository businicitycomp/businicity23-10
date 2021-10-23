using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
   public class SuppourtIdea
    {
        [Key]
        public int SuppourtIdeaID { get; set; }
        public string CompanyName { get; set; }

        public string Commercialrecord { get; set; }
        public string Careerslicense { get; set; }

        public string CertificateofRegistration { get; set; }
        public int Flag { get; set; } = 0;

        public virtual Targetsector Targetsector { get; set; }

        [ForeignKey("TargetsectorID")]
        public int? TargetsectorID { get; set; }

        public virtual TypeCompany TypeCompany { get; set; }

        [ForeignKey("TypeCompanyID")]
        public int? TypeCompanyID { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }


    }
}
