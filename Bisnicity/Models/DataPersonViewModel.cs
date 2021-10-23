using BisnicityApp.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class DataPersonViewModel
    {

        [Required]
        public string Name { get; set; }

        [Required]

        public string Email { get; set; }

        public string phoneeNo { get; set; }

        public int levelID { get; set; }
        public int genderID { get; set; }

        public List<Educationlevel> Educationlevels { get; set; }

        public List<Gender> Genders { get; set; }
        public List<Univircity> univircitys { get; set; }

        public int uniID { get; set; }
    }
}
