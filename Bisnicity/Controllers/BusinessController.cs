using Bisnicity.Helper;
using Bisnicity.Models;
using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using Infrastrucer;
using Infrastrucer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Controllers
{
    public class BusinessController : Controller
    {
        #region Members
        DataContext db;
        private readonly IHostingEnvironment hosting;
        private readonly IBisnicity<Info> Iinfo;
        private readonly IBisnicity<OurServices> Iourservice;
        private readonly IBisnicity<Templete> Itemplet;
        private readonly IBisnicity<Services> Iservices;
        private readonly IBisnicity<PostCompany> Ipost;
        private readonly IBisnicity<jobVacancy> Ijob;
        private readonly IBisnicity<ApplayJob> applayjob;


        #endregion

        #region Constractor


        public BusinessController(IHostingEnvironment _hosting, IBisnicity<Info> _Iinfo, DataContext _db,
            IBisnicity<OurServices> _Iourservice, IBisnicity<Templete> _Itemplet,
            IBisnicity<Services> _Iservices, IBisnicity<PostCompany> _Ipost, IBisnicity<jobVacancy> _Ijob, IBisnicity<ApplayJob> _applayjob)
        {
            hosting = _hosting;
            Iinfo = _Iinfo;
            db = _db;
            Iourservice = _Iourservice;
            Itemplet = _Itemplet;
            Iservices = _Iservices;
            Ipost = _Ipost;
            Ijob = _Ijob;
            applayjob = _applayjob;
        }
        #endregion
        #region Actions
        public IActionResult CompleteProfile()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            int flag = db.Info.Where(x => x.UserId == objComplex.Id).Select(x => x.Flag).FirstOrDefault();
            if (flag == 1)
            {
                return RedirectToAction("Index", "Business");
            }
            else
            {
                return View();

            }
        }
        [HttpPost]
        public IActionResult CompleteProfile(CompleteprofileBusniscssViewModel omodel)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");      
                string imageprofile = string.Empty;
                if (!ModelState.IsValid)
                {
                    return View(nameof(CompleteProfile), omodel);
                }
                if (omodel.ImageProfile != null)
                {
                    imageprofile = UploadedFile(omodel);
                }
                var addinfo = new Info
                {
                    ImageProfile = imageprofile != string.Empty ? imageprofile : string.Empty,
                    CompanyName = omodel.CompanyName,
                    Linklinkedin = omodel.Linklinkedin,
                    UserId = objComplex.Id,
                    Flag = 1
                };
                if (addinfo != null)
                {
                    this.Iinfo.Add(addinfo);
                    return RedirectToAction("Index", "Business");
                }
                return View();
        }

        public IActionResult Index()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            var listinfo = db.Info.SingleOrDefault(x => x.UserId == objComplex.Id);
            var indexinfo = new BusniessViewModel
            {
                InfoID = listinfo.InfoID,
                CompanyName = listinfo.CompanyName,
                Linklinkedin = listinfo.Linklinkedin,
                pathimage = listinfo.ImageProfile,
                FirstName = objComplex.sFirstname,
                LastName = objComplex.sLastname,
                PhoneNo = objComplex.PhoneNumber

            };
            return View(indexinfo);
        }
        public IActionResult EditProfile()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            var listuser = db.Users.Find(objComplex.Id);
            var listedit = new BusniessViewModel
            {
                
                FirstName=listuser.sFirstname,
                LastName=listuser.sLastname,
                PhoneNo=listuser.PhoneNumber,
                CompanyName= db.Info.Where(x => x.UserId == objComplex.Id).Select(x => x.CompanyName).FirstOrDefault(),
                Linklinkedin = db.Info.Where(x => x.UserId == objComplex.Id).Select(x => x.Linklinkedin).FirstOrDefault(),
                pathimage=db.Info.Where(x=>x.UserId == objComplex.Id).Select(x=>x.ImageProfile).FirstOrDefault(),
                InfoID = db.Info.Where(x => x.UserId == objComplex.Id).Select(x => x.InfoID).FirstOrDefault()
            };
            return View(listedit);
        }
        [HttpPost]
        public IActionResult EditProfile(BusniessViewModel omodel)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");

            if (!ModelState.IsValid)
            {
                return View();
            }
            var listedit = new ApplicationUser
            { 
                Id=objComplex.Id,
                sFirstname = omodel.FirstName,
                sLastname = omodel.LastName,
                PhoneNumber = omodel.PhoneNo
            };
            db.Users.Update(listedit);
            var listeditinfo = new Info
            {
                CompanyName = omodel.CompanyName,
                Linklinkedin = omodel.Linklinkedin,
                ImageProfile = omodel.pathimage,
                InfoID = omodel.InfoID,
                UserId = objComplex.Id,
                Flag = 1
            };
            Iinfo.Update(omodel.InfoID, listeditinfo);
            TempData["qqq"] = "Edit Successfuly";
            return RedirectToAction("Index", "Business");
        }

        public IActionResult ShowTemplete()
        {
            var listcattemp = db.CatTemp.ToList();
            return View(listcattemp);
        }

        public IActionResult Ourservice(int? id)
        {
            HttpContext.Session.SetString("CatID", Convert.ToString(id));
            return View();

        }
        [HttpPost]
        public IActionResult Ourservice(OurserviceModels omodel)
        {
            string sLogoTemp = string.Empty;
            string sback = string.Empty;
            if (!ModelState.IsValid)
            {
                TempData["messsages"] = "Please fill in all fields ";
                return View(nameof(Ourservice), omodel);
            }
            if (omodel.File != null)
            {
                sLogoTemp = UploadedLogo(omodel);
            }
            if (omodel.background != null)
            {
                sback = UploadedFilebac(omodel);
            }
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            int sessoncatid = int.Parse(HttpContext.Session.GetString("CatID"));
            var listourservice = new OurServices
            {
                AbuotServ = omodel.AbuotServ,
                AboutUs = omodel.AboutUs,
                City = omodel.City,
                Country = omodel.Country,
                LinkFace = omodel.LinkFace,
                LinkInsta = omodel.LinkInsta,
                LinkTwet = omodel.LinkTwet,
                LinkWats = omodel.LinkWats,
                GoogleMapLink = omodel.GoogleMapLink,
                CompanyNo = omodel.CompanyNo,
                DomainName = omodel.DomainName,
                UserId = objComplex.Id
            };
            var listtem = new Templete
            {
                BackgroundTemp = sback != string.Empty ? sback : string.Empty,
                LogoTemp = sLogoTemp != string.Empty ? sLogoTemp : string.Empty,
                UserId = objComplex.Id,
                ChoesePrice = omodel.ChoesePrice != string.Empty ? omodel.ChoesePrice : string.Empty,
                CatTempID = sessoncatid,
            };
            if (listourservice != null && listtem != null)
            {
                Iourservice.Add(listourservice);
                Itemplet.Add(listtem);

                return RedirectToAction("Addservice", "Business");
            }
            else
            {
                TempData["messsages"] = "Please fill in all fields ";
                return View(nameof(Ourservice), omodel);
            }
        }
        public IActionResult Addservice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addservice(ServicesModel smodel)
        {
            string imageserv = string.Empty;
            if (!ModelState.IsValid)
            {
                return View(nameof(Addservice), smodel);
            }
            if (smodel.Image != null)
            {
                imageserv = UploadedFileSevice(smodel);
            }
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            var listservice = new Services
            {
                Servicename = smodel.Servicename,
                paragraph = smodel.paragraph,
                Image = imageserv != string.Empty ? imageserv : string.Empty,
                UserId = objComplex.Id
            };
            if (listservice != null)
            {
                Iservices.Add(listservice);
                TempData["messsages"] = "Add successful";
                return RedirectToAction("Addservice", "Business");
            }

            return View(nameof(Addservice), smodel);
        }

        public IActionResult ShowPerson(string job)
        {
            if (job != null)
            {
                List<ShowPersonViewModel> oShowPersonViewModel = new List<ShowPersonViewModel>();
                var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
                List<Person> lstPerson = db.Person.ToList();

                DetailsPerson[] listdetailsperson = db.DetailsPerson.ToList().ToArray();


                if (listdetailsperson != null && listdetailsperson.Length > 0)
                {
                    foreach (var item in listdetailsperson.ToList())
                    {
                        oShowPersonViewModel.Add(new ShowPersonViewModel
                        {
                            Address = lstPerson.Where(x => x.Address == item.UserId).Select(c => c.Address).FirstOrDefault(),
                            FirstName = db.Users.Where(x => x.sFirstname == item.UserId).Select(c => c.sFirstname).FirstOrDefault(),

                            LastName = db.Users.Where(x => x.sLastname == item.UserId).Select(c => c.sLastname).FirstOrDefault(),
                            PhoneNo = db.Users.Where(x => x.PhoneNumber == item.UserId).Select(c => c.PhoneNumber).FirstOrDefault(),
                            Email = db.Users.Where(x => x.Email == item.UserId).Select(c => c.Email).FirstOrDefault(),
                            Age = lstPerson.Where(x => x.Age == item.UserId).Select(c => c.Age).FirstOrDefault(),
                            LinkedIn = lstPerson.Where(x => x.LinkedInLink == item.UserId).Select(c => c.LinkedInLink).FirstOrDefault(),
                            Major = lstPerson.Where(x => x.Major == item.UserId).Select(c => c.Major).FirstOrDefault(),
                            Pathimage = lstPerson.Where(x => x.PersonImage == item.UserId).Select(c => c.PersonImage).FirstOrDefault(),
                            Expirence = item.Expirence,
                            AboutUs = item.AboutUs

                        });
                    }
                    return View(oShowPersonViewModel.ToList());

                }
            }
            return RedirectToAction("indexshowcomp", "Home");


           
        }
        public IActionResult ShowApplay()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            if (objComplex == null)
            {
                return RedirectToAction("Login", "SignUp");
            }
            List<ShowPersonViewModel> oShowPersonViewModel = new List<ShowPersonViewModel>();
            var listjob = applayjob.List().Where(x => x.UserId == objComplex.Id);
            ApplayJob[] applays = applayjob.List().Where(x => x.UserId == objComplex.Id).ToArray();
            List<jobVacancy> job = db.jobVacancy.ToList();
            List<Person> person = db.Person.ToList();
                     
            foreach (var item in applays.ToList())
            {
                oShowPersonViewModel.Add(new ShowPersonViewModel
                {
                    jobName = job.Where(x => x.JobName == item.JobVacancy.JobName).Select(x => x.JobName).FirstOrDefault(),
                    FirstName = db.Users.Where(x => x.sFirstname == item.UserId).Select(c => c.sFirstname).FirstOrDefault(),
                    Email = db.Users.Where(x => x.Email == item.UserId).Select(c => c.Email).FirstOrDefault(),
                    PhoneNo = db.Users.Where(x => x.PhoneNumber == item.UserId).Select(c => c.PhoneNumber).FirstOrDefault(),
                    Major = person.Where(x => x.Major == item.UserId).Select(c => c.Major).FirstOrDefault(),
                    Pathimage = person.Where(x => x.PersonImage == item.UserId).Select(c => c.PersonImage).FirstOrDefault(),

                });
                foreach (var i in listjob)
                {
                    oShowPersonViewModel.Add(new ShowPersonViewModel
                    {
                        jobName = i.JobVacancy.JobName,
                        FirstName = db.Users.Where(x=>x.sFirstname == i.UserId).Select(x=>x.sFirstname).FirstOrDefault(),
                        Email = db.Users.Where(x => x.Email == i.UserId).Select(x => x.Email).FirstOrDefault(),
                        PhoneNo = db.Users.Where(x => x.PhoneNumber == i.UserId).Select(x => x.PhoneNumber).FirstOrDefault(),
                        Major = person.Where(x=>x.Major == i.UserId).Select(x=>x.Major).FirstOrDefault(),
                        Pathimage =person.Where(x=>x.PersonImage == i.UserId).Select(x=>x.PersonImage).FirstOrDefault()

                    });;
                }
            }
            return View(oShowPersonViewModel.ToList());
        }
        [HttpPost]
        public IActionResult AddPost(BusniessViewModel model)
        {
            string imagePost = string.Empty;
            if (model.postimage != null)
            {
                imagePost = UploadedPost(model);
            }
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            var addpostdata = new PostCompany
            {
                DetailsPost = model.detailspost,
                ImagePost = imagePost != string.Empty ? imagePost : string.Empty,
                UserId = objComplex.Id,
                TitelePost = model.Tittelpost

            };
            if (addpostdata != null)
            {
                Ipost.Add(addpostdata);
            }
            return RedirectToAction("Index", "Business", TempData["messsages"] = "Add Post Successful");
        }
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(jobVacancy job)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(AddJob), job);
            }
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            var addjobs = new jobVacancy
            {
                JobType = job.JobType,
                JobName = job.JobName,
                Experience = job.Experience,
                Requirements = job.Requirements,
                Address = job.Address,
                Salary = job.Salary,
                UserId = objComplex.Id,
                Email = job.Email,
                PhoneNo = job.PhoneNo,
                CompanyName = job.CompanyName,
                LinkkedIn = job.LinkkedIn
            };
            if (addjobs != null)
            {
                Ijob.Add(addjobs);
                TempData["messsages"] = "Add Job is successful";
                return RedirectToAction("AddJob", "Business");
            }
            return View();
        }
        public IActionResult ShowJob()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            List<ShowCompanyViewmodel> oShowCompanyViewModel = new List<ShowCompanyViewmodel>();
            jobVacancy[] listjob = db.jobVacancy.Where(c => c.UserId == objComplex.Id).ToArray();
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
                        NameJob = item.JobName,
                        jobvacancyid = item.jobVacancyID,
                    });

                }

                return View(oShowCompanyViewModel.ToList());
            }
            return View();
        }
        public IActionResult DeleteJob(int id)
        {
            Ijob.Delete(id);
            return RedirectToAction("ShowJob", "Business");
        }
        public IActionResult MyPost()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            var listpost = db.PostCompany.Where(x => x.UserId == objComplex.Id).ToList();
            return View(listpost);
        }
        public IActionResult DeletePost(int id)
        {
            Ipost.Delete(id);
            return RedirectToAction("MyPost", "Business", TempData["Message"] = "Delete Sucssfuly");
        }


        #endregion
        #region Methods
        private string UploadedFileSevice(ServicesModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private string UploadedFile(CompleteprofileBusniscssViewModel omodel)
        {
            string uniqueFileName = null;

            if (omodel.ImageProfile != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "ProfilImage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + omodel.ImageProfile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    omodel.ImageProfile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        private string UploadedLogo(OurserviceModels omodel)
        {
            string uniqueFileName = null;

            if (omodel.File != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + omodel.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    omodel.File.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        private string UploadedFilebac(OurserviceModels model)
        {
            string uniqueFileName = null;

            if (model.background != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.background.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.background.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        private string UploadedPost(BusniessViewModel model)
        {
            string uniqueFileName = null;

            if (model.postimage != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "postImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.postimage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.postimage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        #endregion
    }
}
