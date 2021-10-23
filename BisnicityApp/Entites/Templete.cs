using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
    public class Templete
    {
        [Key]
        [Required]
        public int TempleteID { get; set; }
        [Required]
        public string BackgroundTemp { get; set; }

        public string LogoTemp { get; set; }

        public string ChoesePrice { get; set; }

        public virtual CatTemp CatTemp { get; set; }
        [ForeignKey("CatTempID")]
        public int ? CatTempID { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

    }
}
