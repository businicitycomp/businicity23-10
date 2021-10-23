/*************************************************************************************************************/
/*Class Name    : ProjectRole.cs                                                                       /
/*Created By    : samer sami                                                                            */
/*Ceation Date  : 10-10-2021                                                                            */
/******************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class ProjectRole
    {
        #region Properties
        [Required]
        public string RoleName { get; set; }
        #endregion

    }
}
