using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class ShowCompanyViewmodel
    {
        public int jobvacancyid { get; set; }
        public string NameJob { get; set; }
        public string jobtype { get; set; }
        public string userid { get; set; }

        public string CompanyName { get; set; }

        public string Requirements { get; set; }

        public string Experience { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }
        public string Linklinkedin { get; set; }

        public string City { get; set; }

        public int jobadminID { get; set; }
    }
}
