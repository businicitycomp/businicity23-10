/*************************************************************************************************************/
/*Class Name    : PersonController.cs                                                                       /
/*Created By    : samer sami                                                                            */
/*Ceation Date  :                                                                            */
/******************************************************************************************************/
using Bisnicity.Helper;
using Bisnicity.Models;
using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using Infrastrucer;
using Infrastrucer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Controllers
{
    [Authorize(Roles = BisnicityKey.PersonRole)]
    public class PersonController : Controller
    {
        #region members


        private readonly IBisnicity<Person> persondata;
        private readonly IBisnicity<Info> compdata;
        private readonly IBisnicity<DetailsPerson> addDetailsperson;
        private readonly IBisnicity<SkillsPerson> addskills;
        private readonly IBisnicity<ApplayJob> applayjob;
        private readonly IHostingEnvironment hosting;
        private readonly IBisnicity<Univircity> uni;
        private readonly IBisnicity<Educationlevel> edu;
        private readonly IBisnicity<Person> Iperson;
        private readonly DataContext dataContext;
        private readonly SignInManager<ApplicationUser> osignInManager;
        public PersonController(IBisnicity<Person> operson, DataContext _dataContext, IBisnicity<DetailsPerson> _addDetailsperson,
            IHostingEnvironment hosting, IBisnicity<SkillsPerson> _addskills,
            IBisnicity<Info> _compdata,/* IBisnicity<ApplayJob> _applayjob,*/ IBisnicity<Univircity> _uni,
            IBisnicity<Educationlevel> _edu, IBisnicity<Person> _Iperson,
            SignInManager<ApplicationUser> signInManager)
        {
            persondata = operson;
            dataContext = _dataContext;
            addDetailsperson = _addDetailsperson;
            addskills = _addskills;
            this.hosting = hosting;
            compdata = _compdata;
            //applayjob = _applayjob;
            uni = _uni;
            edu = _edu;
            Iperson = _Iperson;
            osignInManager = signInManager;
        }
        #endregion

        #region Methods


        public IActionResult IndexPerson()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var listperson = dataContext.Person.SingleOrDefault(x => x.UserId == objComplex.Id);
                var personlist = new ViewPersonViewModel
                {
                    FirsName = objComplex.sFirstname,
                    LastName = objComplex.sLastname,
                    Email = objComplex.Email,
                    PhoneNo = objComplex.PhoneNumber,
                    Linklinkedin = listperson.LinkedInLink,
                    Age = listperson.Age,
                    pathimage = listperson.PersonImage

                };
                return View(personlist);
            }

        }
        public IActionResult CompleteProfilePerson()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            int flag = dataContext.Person.Where(x => x.UserId == objComplex.Id).Select(x => x.Flag).FirstOrDefault();
            if(flag== 1)
            {
                return RedirectToAction("IndexPerson", "Person");
            }
            else
            {
                var signview = new CompleteProfilePersonViewModels
                {
                    Educationlevels = fillselect(),
                    univircitys = FillselectUni()
                };
                return View(signview);
            }
           
        }
        [HttpPost]
        public IActionResult CompleteProfilePerson(CompleteProfilePersonViewModels omodel)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            if (omodel.levelID == -1 && omodel.uniID == -1)
            {
                TempData["messsages"] = "please chosee Gender and Level Educations and univircity";
                var osignview = new CompleteProfilePersonViewModels
                {

                    Educationlevels = fillselect(),
                    univircitys = FillselectUni()
                };
                TempData["messsages"] = "please chosee Gender and Level Educations and univircity";
                return View(osignview);

            }
            string cv = string.Empty;
            string imageprofile = string.Empty;

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (omodel.uploadscv != null)
            {
                cv = UploadedFileCv(omodel);
            }

            if (omodel.uploadpersonimage != null)
            {
                imageprofile = UploadedFileperson(omodel);

            }
            var edufind = edu.Find(omodel.levelID);
            var unifind = uni.Find(omodel.uniID);
            int eduid = edufind.EducationlevelID;
            int uniID = unifind.UnivircityID;
            var listperson = new Person
            {
                LinkedInLink = omodel.LinkedInLink,
                Age = omodel.Age,
                GPA = omodel.GPA,
                Address = omodel.Address,
                PersonImage = imageprofile != string.Empty ? imageprofile : string.Empty,
                EducationlevelID = eduid,
                UnivircityID = uniID,
                Major = omodel.Major,
                Cvpdf = cv != string.Empty ? cv : string.Empty,
                UserId=objComplex.Id,
                Flag=1
            };
            if (listperson != null)
            {
                Iperson.Add(listperson);
                return RedirectToAction("IndexPerson", "Person");
            }


            return View();
        }

        //public IActionResult EditProfilePerson()
        //{
        //    if (HttpContext.Session.GetString("PersonID") == null)
        //    {
        //        return RedirectToAction("LoginPerson", "SignUp");
        //    }
        //    else
        //    {
        //        int sessionperson = int.Parse(HttpContext.Session.GetString("PersonID"));

        //        var personlist = persondata.Find(sessionperson);

        //        var mode = new SignUpPersonViewModel
        //        {
        //            PersonID= personlist.PersonID,
        //            FirstName=personlist.FirstName,
        //            LastName= personlist.LastName,
        //            SecoundName=personlist.SecoundName,
        //            ThirdName=personlist.ThirdName,
        //            Age=personlist.Age,
        //            Address=personlist.Address,
        //            Email=personlist.Email,
        //            phoneNo=personlist.phoneNo,
        //            LinkedInLink=personlist.LinkedInLink,
        //            Password=personlist.Password,
        //            GPA=personlist.GPA,
        //            PersonImagePath=personlist.PersonImage,
        //            CreatedAtPerson=personlist.CreatedAtPerson,
        //            pdfbath = personlist.Cvpdf,
        //            Major=personlist.Major


        //        };
        //        return View(mode);
        //    }
        //}

        [HttpPost]
        //public IActionResult EditProfilePerson(SignUpPersonViewModel personmodel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(personmodel);
        //    }
        //    int sessionperson = int.Parse(HttpContext.Session.GetString("PersonID"));
        //    var update = new Person
        //    {
        //        PersonID = personmodel.PersonID,
        //        FirstName = personmodel.FirstName,
        //        LastName = personmodel.LastName,
        //        SecoundName = personmodel.SecoundName,
        //        ThirdName = personmodel.ThirdName,
        //        Age = personmodel.Age,
        //        Address = personmodel.Address,
        //        Email = personmodel.Email,
        //        phoneNo = personmodel.phoneNo,
        //        LinkedInLink = personmodel.LinkedInLink,
        //        Password = personmodel.Password,
        //        GPA = personmodel.GPA,
        //        PersonImage = personmodel.PersonImagePath,
        //        CreatedAtPerson = personmodel.CreatedAtPerson,
        //        Cvpdf=personmodel.pdfbath,
        //        Major=personmodel.Major

        //    };
        //    persondata.Update(personmodel.PersonID, update);
        //    TempData["editsucc"] = "Edit Successfuly";
        //    return RedirectToAction("EditProfilePerson", "Person");
        //}
        [HttpGet]
        public IActionResult TempOfPerson()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            else
            {

                var data = dataContext.CatPerson.ToList();
                return View(data);

            }
        }

        public IActionResult AddPerson(int? id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            else
            {
                HttpContext.Session.SetString("CatPersonID", Convert.ToString(id));

                return View();

            }
        }
        [HttpPost]
        public IActionResult AddPerson(DetailpersonViewModel odetailsPerson)
        {
            string aboutPerson = UploadedFile(odetailsPerson);
            if (!ModelState.IsValid)
            {
                TempData["messsages"] = "Please fill in all fields ";
                return View(nameof(AddPerson), odetailsPerson);
            }
            else
            {
                var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
                int sessoncatidperson = int.Parse(HttpContext.Session.GetString("CatPersonID"));
                var add = new DetailsPerson
                {
                    AboutUs = odetailsPerson.AboutUs,
                    Expirence = odetailsPerson.Expirence,
                    Whatslink = odetailsPerson.Whatslink,
                    Facebooklink = odetailsPerson.Facebooklink,
                    CatPersonID = sessoncatidperson,
                    UserId = objComplex.Id,
                    AboutImage = aboutPerson != string.Empty ? aboutPerson : string.Empty
                   



                };
                addDetailsperson.Add(add);
                return RedirectToAction("AddSkillsPerson", "Person");

            }

        }

        public IActionResult AddSkillsPerson()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            else
            {
                return View();

            }
        }
        [HttpPost]
        public IActionResult AddSkillsPerson(SkillsPerson oskillsPerson)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            if (!ModelState.IsValid)
            {
                return View(nameof(AddSkillsPerson), oskillsPerson);
            }
            else
            {
                var addskill = new SkillsPerson
                {
                    SkillsName = oskillsPerson.SkillsName,
                    Courses = oskillsPerson.Courses,
                    UserId = objComplex.Id
                };
                addskills.Add(addskill);
                TempData["editsucc"] = "Add suces ";
                return RedirectToAction("AddSkillsPerson", "Person");

            }

        }

        public IActionResult ShowCompanyJob(string job)
        {
            if (job != null)
            {
                List<ShowCompanyViewmodel> oShowCompanyViewModelq = new List<ShowCompanyViewmodel>();

                jobVacancy[] listjobq = dataContext.jobVacancy.Where(x => x.JobType.Contains(job)).ToList().ToArray();

                if (listjobq != null && listjobq.Length > 0)
                {
                    foreach (var item in listjobq.ToList())
                    {

                        oShowCompanyViewModelq.Add(new ShowCompanyViewmodel
                        {
                            Email = item.Email,
                            CompanyName = item.CompanyName,
                            PhoneNo = item.PhoneNo,
                            Linklinkedin = item.LinkkedIn,
                            Experience = item.Experience,
                            Requirements = item.Requirements,
                            City = item.Address,
                            userid=item.UserId,
                            NameJob = item.JobName,
                            jobvacancyid = item.jobVacancyID,
                        });

                    }
                    //return View(postdata);
                    return View(oShowCompanyViewModelq.ToList());
                }
            }
            List<ShowCompanyViewmodel> oShowCompanyViewModel = new List<ShowCompanyViewmodel>();
            jobVacancy[] listjob = dataContext.jobVacancy.ToList().ToArray();
            if (listjob != null && listjob.Length > 0)
            {
                foreach (var item in listjob.ToList())
                {

                    oShowCompanyViewModel.Add(new ShowCompanyViewmodel
                    {
                        Email = item.Email,
                        CompanyName = item.CompanyName,
                        PhoneNo = item.PhoneNo,
                        Linklinkedin = item.LinkkedIn,
                        Experience = item.Experience,
                        Requirements = item.Requirements,
                        City = item.Address,
                        userid = item.UserId,
                        NameJob = item.JobName,
                        jobvacancyid = item.jobVacancyID,
                    });

                }

                return View(oShowCompanyViewModel.ToList());
            }
            else
            {
                return View();
            }
        }
        public IActionResult ShowCompanyJobAR(string job)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            if (job != null)
            {
                List<ShowCompanyViewmodel> oShowCompanyViewModelq = new List<ShowCompanyViewmodel>();

                jobVacancy[] listjobq = dataContext.jobVacancy.Where(x => x.JobType.Contains(job)).ToList().ToArray();

                if (listjobq != null && listjobq.Length > 0)
                {
                    foreach (var item in listjobq.ToList())
                    {

                        oShowCompanyViewModelq.Add(new ShowCompanyViewmodel
                        {
                            Email = item.Email,
                            CompanyName = item.CompanyName,
                            PhoneNo = item.PhoneNo,
                            Linklinkedin = item.LinkkedIn,
                            Experience = item.Experience,
                            Requirements = item.Requirements,
                            City = item.Address,
                            NameJob = item.JobName,
                            userid = item.UserId,
                            jobvacancyid = item.jobVacancyID,
                        });

                    }
                    //return View(postdata);
                    return View(oShowCompanyViewModelq.ToList());
                }
            }

            List<ShowCompanyViewmodel> oShowCompanyViewModel = new List<ShowCompanyViewmodel>();

            jobVacancy[] listjob = dataContext.jobVacancy.ToList().ToArray();

            if (listjob != null && listjob.Length > 0)
            {
                foreach (var item in listjob.ToList())
                {

                    oShowCompanyViewModel.Add(new ShowCompanyViewmodel
                    {
                        Email = item.Email,
                        CompanyName = item.CompanyName,
                        PhoneNo = item.PhoneNo,
                        Linklinkedin = item.LinkkedIn,
                        Experience = item.Experience,
                        Requirements = item.Requirements,
                        City = item.Address,
                        userid = item.UserId,
                        NameJob = item.JobName,
                        jobvacancyid = item.jobVacancyID,
                    });

                }

                return View(oShowCompanyViewModel.ToList());
            }
            else
            {
                return View();
            }
        }

        public IActionResult ShowCompanyJob2(string job)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            if (job != null)
            {
                List<ShowCompanyViewmodel> oShowCompanyViewModelq = new List<ShowCompanyViewmodel>();

                jobVacancy[] listjobq = dataContext.jobVacancy.Where(x => x.JobType.Contains(job)).ToList().ToArray();

                if (listjobq != null && listjobq.Length > 0)
                {
                    foreach (var item in listjobq.ToList())
                    {

                        oShowCompanyViewModelq.Add(new ShowCompanyViewmodel
                        {
                            Email = item.Email,
                            CompanyName = item.CompanyName,
                            PhoneNo = item.PhoneNo,
                            Linklinkedin = item.LinkkedIn,
                            Experience = item.Experience,
                            Requirements = item.Requirements,
                            City = item.Address,
                            NameJob = item.JobName,
                            userid = item.UserId,
                            jobvacancyid = item.jobVacancyID,
                        });

                    }
                    //return View(postdata);
                    return View(oShowCompanyViewModelq.ToList());
                }
            }

            List<ShowCompanyViewmodel> oShowCompanyViewModel = new List<ShowCompanyViewmodel>();

            jobVacancy[] listjob = dataContext.jobVacancy.ToList().ToArray();

            if (listjob != null && listjob.Length > 0)
            {
                foreach (var item in listjob.ToList())
                {

                    oShowCompanyViewModel.Add(new ShowCompanyViewmodel
                    {
                        Email = item.Email,
                        CompanyName = item.CompanyName,
                        PhoneNo = item.PhoneNo,
                        Linklinkedin = item.LinkkedIn,
                        Experience = item.Experience,
                        Requirements = item.Requirements,
                        City = item.Address,
                        userid = item.UserId,
                        NameJob = item.JobName,
                        jobvacancyid = item.jobVacancyID,
                    });

                }

                return View(oShowCompanyViewModel.ToList());
            }
            return View();

        }
        [HttpPost]
        public IActionResult Aplayjob(int? id , string ? id2)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");


            var addaplay = new ApplayJob
            {
                 
                JobVacancyID = id,
                UserId =objComplex.Id,
                UserbusID=id2
            };
            if (addaplay != null)
            {
                applayjob.Add(addaplay);

            }
            return RedirectToAction("ShowCompanyJob2", "Person", TempData["qqq"] = "Applay Successfuly");
        }
        #endregion

        #region UploadsFile
        private string UploadedFile(DetailpersonViewModel model)
        {
            string uniqueFileName = null;

            if (model.File != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.File.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        #endregion
        #region List && Methods
        List<Educationlevel> fillselect()
        {
            var edulist = edu.List().ToList();
            edulist.Insert(0, new Educationlevel { EducationlevelID = -1, levelName = "----please select an Education Level------" });
            return edulist;

        }

        List<Univircity> FillselectUni()
        {
            var unilist = uni.List().ToList();
            unilist.Insert(0, new Univircity { UnivircityID = -1, UniName = "------ please select Univircity Name" });
            return unilist;
        }
        private string UploadedFileperson(CompleteProfilePersonViewModels model)
        {
            string uniqueFileName = null;

            if (model.uploadpersonimage != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "ProfilImage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.uploadpersonimage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.uploadpersonimage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        private string UploadedFileCv(CompleteProfilePersonViewModels model)
        {
            String FileExt = Path.GetExtension(model.uploadscv.FileName).ToUpper();
            string uniqueFileName = null;
            if (FileExt == ".PDF")
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "uploadsCV");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.uploadscv.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.uploadscv.CopyTo(fileStream);
                }

            }
            return uniqueFileName;
        }
        #endregion
    }
}
