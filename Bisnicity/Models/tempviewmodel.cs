using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class tempviewmodel
    {
        public int tempid { get; set; }

        public string ? userid { get; set; }
        public int ? catid { get; set; }
        [DataType(DataType.ImageUrl)]
        public IFormFile logo { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public IFormFile backgroun { get; set; }

        public string choseprice { get; set; }




    }
}
