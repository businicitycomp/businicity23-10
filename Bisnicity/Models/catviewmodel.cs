using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class catviewmodel
    {
        public int catid { get; set; }

        [DataType(DataType.ImageUrl)]
        public IFormFile image { get; set; }

        public string Name { get; set; }
        public string url { get; set; }
        public string OnMonth { get; set; }
        public string SixMointh { get; set; }

        public string OnYears { get; set; }
    }
}
