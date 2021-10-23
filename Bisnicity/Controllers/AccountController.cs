/*************************************************************************************************************/
/*Class Name    : AccountController.cs                                                                       /
/*Created By    : Hamza Nayef                                                                             */
/*Ceation Date  : 09-10-2021                                                                            */
/******************************************************************************************************/
using Bisnicity.Helper;
using Bisnicity.Models;
using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using Infrastrucer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
namespace Bisnicity.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        #region Members
        /// <summary>
        /// 
        /// </summary>
        private readonly UserManager<ApplicationUser> ouserManager;
        private readonly SignInManager<ApplicationUser> osignInManager;
        private readonly ILogger _loggers;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IBisnicity<Gender> gender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IEmailService emailService;

        private LoginViewModel oLoginViewModel { get; set; } = new LoginViewModel();
        #endregion
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_UserManager"></param>
        /// <param name="_signInManager"></param>
        public AccountController(UserManager<ApplicationUser> _UserManager, SignInManager<ApplicationUser> _signInManager, ILogger<AccountController> logger, IBisnicity<Gender> _gender, RoleManager<IdentityRole> _roleManager, IHttpContextAccessor httpContextAccessor)
        {
            this.ouserManager = _UserManager;
            this.osignInManager = _signInManager;
            this._loggers = logger;
            this.gender = _gender;
            roleManager = _roleManager;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion
        #region Actions
        #region Action :: Login
        [ActionName(nameof(Login))]
        public async Task<IActionResult> Login(string sRetrunUrl)
        {
            if (sRetrunUrl == null)
            {
                return View(nameof(Login));
            }
            else if (!string.IsNullOrEmpty(sRetrunUrl))
            {
                oLoginViewModel.sRetrunUrl = sRetrunUrl.Trim();
                return View(nameof(Login), oLoginViewModel);
            }
            return View(nameof(Login));
        }
        #endregion
        #region Action ::Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit(Order = 3)]
        [ActionName(nameof(Login))]
        public async Task<IActionResult> Login(LoginViewModel oLoginViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(nameof(Login), oLoginViewModel);
                }
                var result = await this.osignInManager.PasswordSignInAsync(
                                oLoginViewModel.sEmail,
                                oLoginViewModel.sPassword,
                                oLoginViewModel.bRemberMe,
                                true);
                if (result.Succeeded)
                {
                    string sRoleName = await this.GetUserRole(oLoginViewModel.sEmail);
                    if (!string.IsNullOrEmpty(sRoleName))
                    {
                        if (sRoleName == BisnicityKey.PersonRole)
                        {
                            ApplicationUser user = await ouserManager.FindByEmailAsync(oLoginViewModel.sEmail);
                            HttpContext.Session.SetObject("UserInfo", user);
                            return await this.CustomRedirect("CompleteProfilePerson", "Person");
                        }
                        else if (sRoleName == BisnicityKey.BusinessRole)
                        {
                            ApplicationUser user = await ouserManager.FindByEmailAsync(oLoginViewModel.sEmail);
                            HttpContext.Session.SetObject("UserInfo", user);
                            return await this.CustomRedirect("CompleteProfile", "Business");
                        }
                        else if (sRoleName == BisnicityKey.SuportIdeaRole)
                        {
                            ApplicationUser user = await ouserManager.FindByEmailAsync(oLoginViewModel.sEmail);
                            HttpContext.Session.SetObject("UserInfo", user);
                            return await this.CustomRedirect("SupportIdea", "Idea");
                        }
                        else if (sRoleName == BisnicityKey.InvistorRole)
                        {
                            ApplicationUser user = await ouserManager.FindByEmailAsync(oLoginViewModel.sEmail);
                            HttpContext.Session.SetObject("UserInfo", user);
                            return await this.CustomRedirect("InvestorEN", "Idea");
                        }
                        else if (sRoleName == BisnicityKey.Admin)
                        {
                            ApplicationUser user = await ouserManager.FindByEmailAsync(oLoginViewModel.sEmail);
                            HttpContext.Session.SetObject("Admin", user);
                            return await this.CustomRedirect("AdminPanel", "AdminB");

                        }
                    }
                    else
                    {
                        TempData["Message"] = BisnicityKey.InValidUserName;
                    }
                }
                this.ModelState.AddModelError(string.Empty, string.Concat(BisnicityKey.InValidUserName));
            }
            catch (Exception ex)
            {
                this._loggers.Log(LogLevel.Error, ex.StackTrace, ex);
            }
            return View(nameof(Login));
        }
        #endregion
        #region Action ::Register
        [ActionName(nameof(Register))]
        public async Task<IActionResult> Register()
        {
            var list = new RegiseterViewModel
            {
                Genders = lSelectgender(),
                Roles = lSelctRoles()
            };

            return this.View(nameof(Register), list);
        }
        #endregion
        #region Action :: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Register))]
        public async Task<IActionResult> Register(RegiseterViewModel oRegiseterViewModel)
        {
            try
            {
                ApplicationUser oApplicationUser = null;
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                if (allErrors != null && allErrors.Count() > 0)
                {
                    _loggers.LogError(allErrors.ToString(), string.Empty);
                }
                if (!ModelState.IsValid)
                {
                    var list = new RegiseterViewModel
                    {
                        Genders = lSelectgender(),
                        Roles = lSelctRoles()
                    };
                    return View(nameof(Register), list);
                }
                oApplicationUser = new ApplicationUser();
                oApplicationUser.UserName = oRegiseterViewModel.sEmail;
                oApplicationUser.Email = oRegiseterViewModel.sEmail;
                oApplicationUser.PhoneNumber = oRegiseterViewModel.sPhone;
                oApplicationUser.sFirstname = oRegiseterViewModel.sFirstname;
                oApplicationUser.sLastname = oRegiseterViewModel.sLastname;
                oApplicationUser.GenderID = gender.Find(oRegiseterViewModel.nGenderid).GenderID;
                var result = await this.ouserManager.CreateAsync(oApplicationUser, oRegiseterViewModel.sPassword);
                if (result.Succeeded)
                {
                    await this.ouserManager.AddToRoleAsync(oApplicationUser, oRegiseterViewModel.sRoles);

                    #region confirmation Email
                    var token = await ouserManager.GenerateEmailConfirmationTokenAsync(oApplicationUser);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = oApplicationUser.Email, token }, Request.Scheme);
                    bool emailResponse = EmailHelper.SendEmail(oApplicationUser.Email, confirmationLink);
                    if (emailResponse)
                    {
                        ViewBag.ErrorTitle = "Registration successful";
                        ViewBag.ErrorMessage = "Before you can Login, please confirm your " + "email In Your Email";
                        return View(nameof(ConfirmEmail));
                        //return this.RedirectToAction("Login", "Account");
                    }
                    else { _loggers.LogError("Filed Email Error "); }
                    #endregion
                }
                foreach (var Errors in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, Errors.Description);
                }
            }
            catch (Exception ex)
            {
                this._loggers.Log(LogLevel.Error, ex.StackTrace, ex);
            }
            return View(nameof(Register), oRegiseterViewModel);
        }
        #region Action:: ConfirmEmail
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await ouserManager.FindByEmailAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }
            var result = await ouserManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View("SucssfullyEmail");
            }
            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }

        #endregion
        #region ChangePasswordConfirmationView
        [HttpGet]
        public IActionResult ChangePasswordConfirmationView()
        {
            return View();
        }
        #endregion
        #region Action::ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(Changepasswordviewmodel model)
        {
            if (ModelState.IsValid)
            {
                var user = await ouserManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }
                var result = await ouserManager.ChangePasswordAsync(user,
                    model.Currntpassword, model.sPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await osignInManager.RefreshSignInAsync(user);
                return RedirectToAction("ChangePasswordConfirmation", "Account");
            }

            return View(model);
        }
        #endregion
        #region ForgotPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgetPassword model)
        {
            if (ModelState.IsValid)
            {
                var user = await ouserManager.FindByEmailAsync(model.Email);
                if (user != null && await ouserManager.IsEmailConfirmedAsync(user))
                {
                    var token = await ouserManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                     new { email = model.Email, token = token }, Request.Scheme);
                    bool emailResponse = EmailHelper.SendEmail(user.Email, passwordResetLink);
                    if(emailResponse)
                    {
                        ViewBag.ErrorTitle = "cheek email successful";
                        ViewBag.ErrorMessage = "Before you can Login, please confirm your " + "email In Your Email";
                        return View("ForgotPasswordConfirmation");
                    }
                }
                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }
        #endregion
        #region ResetPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await ouserManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await ouserManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                return View("ResetPasswordConfirmation");
            }
            return View(model);
        }
        #endregion
        #endregion
        #endregion
        #region ListGender
        List<Gender> lSelectgender()
        {
            var genderlist = gender.List().ToList();
            genderlist.Insert(0, new Gender { GenderID = -1, GenderName = "----please select Gender------" });
            return genderlist;

        }
        #region ListRoles
        List<IdentityRole> lSelctRoles()
        {
            var roles = roleManager.Roles.Where(x => !x.Name.Contains("Admin")).ToList();
            //Where(x=>!x.Name.Contains("Admins"))
            return roles;
        }
        #endregion
        #endregion
        #region Method :: GetUserRole
        public async Task<string> GetUserRole(string sEmailID)
        {
            var user = await ouserManager.FindByEmailAsync(sEmailID);
            var rolename = await ouserManager.GetRolesAsync(user);
            return rolename.FirstOrDefault();
        }
        #endregion
    }
}
