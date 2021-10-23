/*************************************************************************************************************
/*Class Name    : RegiseterViewModel.cs                                                                     
/*Created By    : Hamza Nayef                                                                            
/*Ceation Date  : 09-10-2021                                                                            
/*************************************************************************************************************/
namespace Bisnicity.Models
{
    using BisnicityApp.Entites;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class RegiseterViewModel
    {
        #region Properties
        [Required]
        [EmailAddress]
        public string sEmail { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string sPassword { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Compare(nameof(sPassword), ErrorMessage = BisnicityKey.ConfirmPassword)]
        public string sConfirmPassword { get; set; } = string.Empty;
        /// <summary>
        /// Add By:Samer 
        /// Date 10/11/2021
        /// </summary>
        [Required]
        public string sRoles { get; set; }
        public List<IdentityRole> Roles { get; set; } 
        [Required]
        public string sFirstname { get; set; }
        [Required]
        public string sLastname { get; set; }
        [Required]
        public string sPhone { get; set; }

        public int nGenderid { get; set; }
        public List<Gender> Genders { get; set; }

        #endregion
    }
}
