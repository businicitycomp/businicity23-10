using BisnicityApp.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class AddIdeaViewModel
    {
        public string ideaname { get; set; }

        [Required]
        public string descreption { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }

        public string phoneno { get; set; }

        public IFormFile Fileidea { get; set; }

        public int typeideaid { get; set; }
        public List<TypeIdea> TypesIdeas { get; set; }

    }
}
