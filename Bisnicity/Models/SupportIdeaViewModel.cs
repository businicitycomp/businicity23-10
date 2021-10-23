using BisnicityApp.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class SupportIdeaViewModel
    {

        public string CompanyName { get; set; }

        public IFormFile Filerecord { get; set; }

        public IFormFile Filecrt { get; set; }

        public IFormFile Filelicense { get; set; }

        public int typecompid { get; set; }
        public int targetsecid { get; set; }

        public List<TypeCompany> TypeCompanys { get; set; }
        public List<Targetsector> Targetsectors { get; set; }






    }
}
