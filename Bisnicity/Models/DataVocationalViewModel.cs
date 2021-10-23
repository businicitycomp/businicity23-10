using BisnicityApp.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class DataVocationalViewModel
    {

        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string phoneeNo { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        public int genderID { get; set; }

        public int carereid { get; set; }

        public int statusid { get; set; }

        public List<Gender> Genders { get; set; }

        public List<CareerPath> CareerPaths { get; set; }

        public List<yourstatus> yourstatuses { get; set; }





    }
}
