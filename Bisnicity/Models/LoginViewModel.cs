/*************************************************************************************************************
/*Class Name    : LoginViewModel.cs                                                                     
/*Created By    : Hamza Nayef                                                                            
/*Ceation Date  : 09-10-2021                                                                            
/*************************************************************************************************************/
namespace Bisnicity.Models
{
    using System.ComponentModel.DataAnnotations;
    public class LoginViewModel
    {
        #region Properties
        [Required]
        [DataType(DataType.EmailAddress)]
        public string sEmail { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string sPassword { get; set; } = string.Empty;
        public bool bRemberMe { get; set; } = false;
        public string sRetrunUrl { get; set; } = string.Empty;
        #endregion
    }
}
