using BisnicityApp.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class OurserviceModels
    {
        
        public string AbuotServ { get; set; }

        public string AboutUs { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string LinkFace { get; set; }
        public string LinkTwet { get; set; }
        public string LinkInsta { get; set; }
        public string LinkWats { get; set; }
        public string GoogleMapLink { get; set; }

        public int CompanyNo { get; set; }

        public string DomainName { get; set; }

      
        public IFormFile ? File { get; set; }

        public IFormFile ? background { get; set; }


        public string ChoesePrice { get; set; }

        //public int infoID { get; set;}
        public int catID { get; set; }

        
    }
}
