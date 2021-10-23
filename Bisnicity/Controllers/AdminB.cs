/*************************************************************************************************************/
/*Class Name    : AdminBController.cs                                                                       /
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
    [Authorize(Roles =BisnicityKey.Admin)]
    public class AdminB : Controller
    {
        #region Members
            
        private readonly IBisnicity<Info> bisnicity;
        private readonly IBisnicity<Person> Iperson;
        private readonly IBisnicity<OurServices> _ourservice;
        private readonly IBisnicity<Templete> _temp;
        private readonly IBisnicity<Services> addservice;
        private readonly IBisnicity<CatTemp> _category;
        private readonly IBisnicity<jobVacancy> job;
        private readonly IBisnicity<CatPerson> Icatperson;
        private readonly IBisnicity<SkillsPerson> Iskillsperson;
        private readonly IBisnicity<DetailsPerson> Idetailp;
        private readonly IBisnicity<Idea> Iidea;
        private readonly IBisnicity<Invistor> Iinvistor;
        private readonly IBisnicity<SuppourtIdea> Isuportidea;
        private readonly IBisnicity<Datavocational> Idatavoc;
        private readonly IBisnicity<DataPerson> Idataoerson;
        private readonly IBisnicity<PostCompany> Ipost;
        private readonly IBisnicity<volunteer> Ivolunteer;
        private readonly IHostingEnvironment hosting;
        private readonly RoleManager<IdentityRole> roleManger;
        DataContext db;
       
        public AdminB( IHostingEnvironment hosting, IBisnicity<Info> obisnicity,
          IBisnicity<OurServices> ourservice, IBisnicity<Templete> temp, IBisnicity<Services> Addservice,
          IBisnicity<CatTemp> category, IBisnicity<jobVacancy> _job, RoleManager<IdentityRole> _roleManger,
          IBisnicity<Person> _Iperson, IBisnicity<CatPerson> _Icatperson, IBisnicity<DetailsPerson> _Idetailp, IBisnicity<SkillsPerson> _Iskillsperson, 
          IBisnicity<Idea> _Iidea, IBisnicity<Invistor> _Iinvistor, IBisnicity<SuppourtIdea> _Isuportidea, IBisnicity<Datavocational> _Idatavoc,
          IBisnicity<DataPerson> _Idataoerson, IBisnicity<PostCompany> _Ipost, IBisnicity<volunteer> _Ivolunteer,DataContext _Db)
        {
            bisnicity = obisnicity;
            _ourservice = ourservice;
            _temp = temp;
            addservice = Addservice;
            _category = category;
            this.hosting = hosting;
            job = _job;
            roleManger = _roleManger;
            Iperson = _Iperson;
            Icatperson = _Icatperson;
            Idetailp = _Idetailp;
            Iskillsperson = _Iskillsperson;
            Iidea = _Iidea;
            Iinvistor = _Iinvistor;
            Isuportidea = _Isuportidea;
            Idatavoc = _Idatavoc;
            Idataoerson = _Idataoerson;
            Ipost = _Ipost;
            Ivolunteer = _Ivolunteer;
            db = _Db;
        }
        #endregion

        #region CreateRole

        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(ProjectRole role)
        {
            var roleExist = await roleManger.RoleExistsAsync(role.RoleName);
            if(!roleExist)
            {
                var result = await roleManger.CreateAsync(new IdentityRole(role.RoleName));
                return RedirectToAction("AdminPanel", "AdminB", TempData["message"]="Add sucssfuly");
            } 
            
                return View(nameof(CreateRole), role);
        }
        #endregion

        #region Actions

        
        public IActionResult AdminPanel()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            string sessionadmin =objComplex.sFirstname;
            TempData["sessionad"] = sessionadmin;

            return View();
        }

        public IActionResult HomeAdmin()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var iteminfo = this.bisnicity.List();

            return View(iteminfo);
        }
        public IActionResult Editinfo(int id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
           
            var editinfo = this.bisnicity.Find(id);
            return View(editinfo);
        }
        [HttpPost]
        public IActionResult Editinfo(int id, Info info)
        {
            try
            {
                bisnicity.Update(id, info);
                return RedirectToAction(nameof(HomeAdmin));
            }
            catch
            {
                return View();

            }

        }
        public IActionResult Deleteinfo(int id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
           
            var deleteinfo = this.bisnicity.Find(id);
            return View(deleteinfo);
        }
        [HttpPost]
        public IActionResult Deleteinfo(int id,Info info)
        {
           bisnicity.Delete(id);
            return RedirectToAction(nameof(HomeAdmin));
        }
        public IActionResult OurServiceAdmin()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            
            var itemour = this._ourservice.List();

            return View(itemour);
        }
        public IActionResult Editourserv(int id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
           
            var editourser = this._ourservice.Find(id);

            return View(editourser);
        }
        [HttpPost]
        public IActionResult Editourserv(int id , OurServices ourServices)
        {
            try
            {
                _ourservice.Update(id, ourServices);
                return RedirectToAction(nameof(OurServiceAdmin));
            }
            catch
            {
                return View();

            }
        }
        public IActionResult Deleteourserv(int id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
          
            var deleteourserv = this._ourservice.Find(id);
            return View(deleteourserv);
        }
        [HttpPost]
        public IActionResult Deleteourserv(int id,OurServices ourServices)
        {
            _ourservice.Delete(id);
            return RedirectToAction(nameof(OurServiceAdmin));
        }

        public IActionResult Templete()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var itemtemp = this._temp.List();
            return View(itemtemp);
        }
        public IActionResult EditTemp(int id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }

            var edittemp = this._temp.Find(id);
            var edittempviewmodel = new tempviewmodel
            {
                tempid = edittemp.TempleteID,
                userid = edittemp.UserId,
                catid = edittemp.CatTempID,
                choseprice = edittemp.ChoesePrice
            };

            return View(edittempviewmodel);
        }

        [HttpPost]
        public IActionResult EditTemp(int id, tempviewmodel temp)
        {
            string imageserv = UploadedFiletempBAC(temp);
            string imageservLOGO = UploadedFiletempLOGO(temp);

            var tempdata = new Templete
            {
                TempleteID = temp.tempid,
                UserId = temp.userid,
                CatTempID = temp.catid,
                LogoTemp = imageservLOGO != string.Empty ? imageservLOGO : string.Empty,
                BackgroundTemp = imageserv != string.Empty ? imageserv : string.Empty,
                ChoesePrice = temp.choseprice
            };
            try
            {
                _temp.Update(id, tempdata);
                return RedirectToAction(nameof(Templete));
            }
            catch
            {
                return View();
            }

        }
        private string UploadedFiletempBAC(tempviewmodel model)
        {
            string uniqueFileName = null;

            if (model.backgroun != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.backgroun.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.backgroun.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        private string UploadedFiletempLOGO(tempviewmodel model)
        {
            string uniqueFileName = null;

            if (model.logo != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.logo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.logo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        public IActionResult Deletetemp(int id)
        {

            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            
            var deletetemp = this._temp.Find(id);
            return View(deletetemp);
        }
        [HttpPost]
        public IActionResult Deletetemp(int id, Templete temp)
        {
            try
            {
                _temp.Delete(id);
                return RedirectToAction(nameof(Templete));
            }
            catch
            {
                return View();

            }
        }
        public IActionResult Service()
        {

            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
           
            var service = this.addservice.List();
            return View(service);
        }
        public IActionResult Editser(int id)
        {

            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }

            var editserv = this.addservice.Find(id);

            var editservviewmodel = new serviceviewmodel
            {
                ServiceID = editserv.ServicesID,
                Servicename = editserv.Servicename,
                paragraph = editserv.paragraph,
                userid = editserv.UserId


            };
            return View(editservviewmodel);
        }
        [HttpPost]
        public IActionResult Editser(int id, serviceviewmodel services)
        {
            string imageserv = UploadedFile(services);

            var serv = new Services
            {
                ServicesID = services.ServiceID,
                Servicename = services.Servicename,
                paragraph = services.paragraph,
                Image = imageserv != string.Empty ? imageserv : string.Empty,
                UserId = services.userid
            };
            try
            {
                addservice.Update(id, serv);
                return RedirectToAction(nameof(Service));
            }
            catch
            {
                return View();
            }
        }
        private string UploadedFile(serviceviewmodel model)
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
        public IActionResult Deleteserv(int id)
        {

            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
          
            var deleteserv = this.addservice.Find(id);

            return View(deleteserv);
        }

        [HttpPost]
        public IActionResult Deleteserv(int id,Services services)
        {
            try
            {
                addservice.Delete(id);
                return RedirectToAction(nameof(Service));
            }
            catch
            {
                return View();

            }
        }
        public IActionResult CatTemp()
        {

            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
           
            var cat = this._category.List();
            return View(cat);
        }
          public IActionResult Editcat(int id)
          {

            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
           
            var editcat = this._category.Find(id);

            var editcatviewmodel = new catviewmodel
            {
                Name=editcat.Name,
                catid=editcat.CatTempID,
                url=editcat.url,
                OnMonth=editcat.OnMonth,
                SixMointh=editcat.SixMointh,
                OnYears=editcat.OnYears
            };
            return View(editcatviewmodel);
           }
        [HttpPost]
        public IActionResult Editcat(int id, catviewmodel catTemp)
        {
            string imageserv = UploadedFileEditcat(catTemp);

            var editcat = new CatTemp
            {
                CatTempID=catTemp.catid,
                Image= imageserv != string.Empty ? imageserv : string.Empty,
                Name=catTemp.Name,
                url=catTemp.url,
                OnMonth=catTemp.OnMonth,
                SixMointh=catTemp.SixMointh,
                OnYears=catTemp.OnYears

            };

            try
            {
                _category.Update(id, editcat);
                return RedirectToAction(nameof(CatTemp));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Deletecat(int id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }

        
            var deletecat = this._category.Find(id);

            return View(deletecat);
        }
        [HttpPost]
        public IActionResult Deletecat(int id , CatTemp catTemp)
        {
            try
            {
                _category.Delete(id);
                return RedirectToAction(nameof(CatTemp));
            }
            catch
            {
                return View();

            }

        }

        public IActionResult CreateCat()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult CreateCat(catviewmodel catTemp)
        {
            string imagecat = UploadedFileCat(catTemp);

            var cat = new CatTemp
            {
                CatTempID=catTemp.catid,
                Image = imagecat != string.Empty ? imagecat : string.Empty,
                url=catTemp.url,
                Name=catTemp.Name,
                OnMonth=catTemp.OnMonth,
                SixMointh=catTemp.SixMointh,
                OnYears=catTemp.OnYears

            };
            if (cat != null)
            {
                this._category.Add(cat);
                return RedirectToAction(nameof(CatTemp));

            }
            return View();
        }

        public IActionResult profilePerson()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listperson = Iperson.List();
            return View(listperson);
        }

        public IActionResult CatPrson()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");
            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var catperson = Icatperson.List();
            return View(catperson);
        }
        public IActionResult CreatCatPerson()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");
            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public IActionResult CreatCatPerson(catviewmodel model)
        {
            string imagecat = UploadedFileCat(model);
            var listcatperson = new CatPerson
            {
                Name=model.Name,
                url=model.url,
                Image = imagecat != string.Empty ? imagecat : string.Empty
            };
            Icatperson.Add(listcatperson);
            return View(nameof(CatPrson));

        }
        public IActionResult EditcatPerson(int id)
        {

            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }

            var listPerson = this.Icatperson.Find(id);

            var editcatviewmodel = new catviewmodel
            {
                Name = listPerson.Name,
                catid = listPerson.CatPersonID,
                url = listPerson.url
             
            };
            return View(editcatviewmodel);
        }
        [HttpPost]
        public IActionResult EditcatPerson(int id, catviewmodel catTemp)
        {
            string imageserv = UploadedFileEditcat(catTemp);

            var editcat = new CatPerson
            {
                CatPersonID = catTemp.catid,
                Image = imageserv != string.Empty ? imageserv : string.Empty,
                Name = catTemp.Name,
                url = catTemp.url
            };

            try
            {
                Icatperson.Update(id, editcat);
                return RedirectToAction(nameof(CatTemp));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult DeleteCatperson(int id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var deletecatperson = Icatperson.Find(id);
            return View(deletecatperson);
        }
        [HttpPost]
        public IActionResult DeleteCatperson(int id, CatPerson model)
        {
            Icatperson.Delete(id);
            return View(nameof(CatPrson));
        }
        public IActionResult DetailsPerson()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listdetailp = Idetailp.List();
            return View(listdetailp);
        }
        
        public IActionResult EditDetailsPerson(int id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listperson = Idetailp.Find(id);
            return View(listperson);
        }
        [HttpPost]
        public IActionResult EditDetailsPerson(int id,DetailsPerson model)
        {
            Idetailp.Update(id, model);
            return View(nameof(DetailsPerson));
        }
        public IActionResult DeleteDetailsPerson(int id)
        {
          var listdetails=  Idetailp.Find(id);
            return View(listdetails);
        }
        [HttpPost]
        public IActionResult DeleteDetailsPerson(int id,DetailsPerson model)
        {
            Idetailp.Delete(id);
            return View(nameof(DetailsPerson));

        }
        public IActionResult SkillsPerson()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listskillsperson = Iskillsperson.List();
            return View(listskillsperson);
        }
        public IActionResult EditSkillsPerson(int id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listedit = Iskillsperson.Find(id);
            return View(listedit);
        }
        [HttpPost]
        public IActionResult EditSkillsPerson(int id,SkillsPerson model)
        {
            Iskillsperson.Update(id,model);
            return View(nameof(SkillsPerson));
        }
        public IActionResult DeleteSkillsPerson(int id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listskills = Iskillsperson.Find(id);
            return View(listskills);
        }
        [HttpPost]
        public IActionResult DeleteSkillsPerson(int id,SkillsPerson model)
        {
            Iskillsperson.Delete(id);
            return View(nameof(SkillsPerson));

        }
        private string UploadedFileEditcat(catviewmodel model)
        {
            string uniqueFileName = null;

            if (model.image != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "UploadsCategory");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private string UploadedFileCat(catviewmodel model)
        {
            string uniqueFileName = null;

            if (model.image != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "UploadsCategory");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

      
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AddJobAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJobAdmin(jobVacancy model)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (!ModelState.IsValid)
            {
                return View(nameof(AddJobAdmin), model);
            }
            else
            {
                var listjob = new jobVacancy
                {
                    JobType=model.JobType,
                    JobName=model.JobName,
                    Email=model.Email,
                    Experience=model.Experience,
                    Salary=model.Salary,
                    PhoneNo=model.PhoneNo,
                    Address=model.Address,
                    Requirements=model.Requirements,
                    CompanyName=model.CompanyName,
                    UserId=objComplex.Id,
                    LinkkedIn=model.LinkkedIn
                };
                job.Add(listjob);
                return RedirectToAction("AddJobAdmin", "AdminB");
               
            }
            
        }
        public IActionResult Idea()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listidea = Iidea.List();
            return View(listidea);
        }
        public IActionResult DeleteIdea(int id)
        {
            var listidea = Iidea.Find(id);
            return View(listidea);
        }
        [HttpPost]
        public IActionResult DeleteIdea(int id, Idea model)
        {
            Iidea.Delete(id);
            return View(nameof(Idea));
        }
        public IActionResult Invistor()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listinvistor = Iinvistor.List();
            return View(listinvistor);
        }
        public IActionResult SuportIdea()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listsuportidea = Isuportidea.List();
            return View(listsuportidea);
        }
        public IActionResult DataVocation()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listdatavoc = Idatavoc.List();
            return View(listdatavoc);
        }
        public IActionResult DataPersonTranning()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listdataperson = Idataoerson.List();
            return View(listdataperson);
        }
        public IActionResult Post()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listpost = Ipost.List();
            return View(listpost);
        }
        public IActionResult Deletepost(int id)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listpost = Ipost.Find(id);
            return View(listpost);
        }
        [HttpPost]
        public IActionResult Deletepost(int id, PostCompany model)
        {
            Ipost.Delete(id);
            return View(nameof(Post));
        }
        public IActionResult Volunteer()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("Admin");

            if (objComplex == null)
            {
                return RedirectToAction("Login", "Account");

            }
            var listvolunteer = Ivolunteer.List();
            return View(listvolunteer);

        }
        public IActionResult Users()
        {
            var lisuser = db.Users.ToList();
            return View(lisuser);
        }


        #endregion
    }
}

