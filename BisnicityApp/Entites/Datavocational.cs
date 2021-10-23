using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.Entites
{
   public class Datavocational
    {
        [Key]
        public int DatavocationalID { get; set; }

        public string Name { get; set; }

        [Required]

        public string Email { get; set; }

        public string phoneeNo { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        public virtual Gender Gender { get; set; }
        [ForeignKey("GenderID")]
        public int? GenderID { get; set; }
        public virtual CareerPath CareerPath { get; set; }
        [ForeignKey("CareerPathID")]
        public int? CareerPathID { get; set; }

        public virtual yourstatus yourstatus { get; set; }
        [ForeignKey("yourstatusID")]
        public int? yourstatusID { get; set; }



    }
}
