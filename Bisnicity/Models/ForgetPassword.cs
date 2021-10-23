/*************************************************************************************************************/
/*Class Name    : HomeController.cs                                                                       /
/*Created By    : samer sami                                                                            */
/*Ceation Date  :   10/102021                                                                         */
/******************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Models
{
    public class ForgetPassword
    {
        #region Properties
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        #endregion

    }
}
