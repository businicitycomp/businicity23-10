using BisnicityApp.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class InvistorViewModel
    {
        public string CompanyName { get; set; }

        public int targetsecid { get; set; }
        public List<Targetsector> Targetsectors { get; set; }
    }
}
