using Bisnicity.Helper;
using Bisnicity.Models;
using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using Infrastrucer;
using Infrastrucer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Controllers
{
    [AllowAnonymous]
    public class IdeaController : Controller
    {
        #region Members
        private readonly IHostingEnvironment hosting;
        private readonly IBisnicity<Idea> Iaddidea;
        private readonly IBisnicity<TypeIdea> Itypeidea;
        private readonly IBisnicity<Targetsector> Itarget;
        private readonly IBisnicity<Invistor> Iinvisto;
        private readonly IBisnicity<TypeCompany> Itypecomp;
        private readonly IBisnicity<SuppourtIdea> Iaddsup;
        private readonly IBisnicity<DataPerson> Iadddataperson;
        private readonly IBisnicity<Educationlevel> Iedu;
        private readonly IBisnicity<Univircity> Iuni;
        private readonly IBisnicity<Gender> Igender;
        DataContext db;
        public IdeaController(IHostingEnvironment _hosting, IBisnicity<Idea> _Iaddidea, IBisnicity<TypeIdea> _Itypeidea,
             IBisnicity<Targetsector> _Itarget, IBisnicity<Invistor> _Iinvisto, IBisnicity<TypeCompany> _Itypecomp, 
             IBisnicity<SuppourtIdea> _Iaddsup,DataContext _db, IBisnicity<DataPerson> _Iadddataperson,
             IBisnicity<Educationlevel> _Iedu, IBisnicity<Univircity> _Iuni, IBisnicity<Gender> _Igender)
        {
            hosting = _hosting;
            Iaddidea = _Iaddidea;
            Itypeidea = _Itypeidea;
            Itarget = _Itarget;
            Iinvisto = _Iinvisto;
            Itypecomp = _Itypecomp;
            Iaddsup = _Iaddsup;
            db = _db;
            Iadddataperson = _Iadddataperson;
            Iedu = _Iedu;
            Iuni = _Iuni;
            Igender = _Igender;
        }
        #endregion
        #region Actions

        public IActionResult IndexEn()
        {
            return View();
        }
        public IActionResult IndexAR()
        {
            return View();
        }

        public IActionResult AddIdea()
        {
            var signview = new AddIdeaViewModel
            {
                TypesIdeas = fillselectTypeIDea()
            };
            return View(signview);
        }
        [HttpPost]
        public IActionResult AddIdea(AddIdeaViewModel model)
        {
            string fileidea =string.Empty;

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (model.typeideaid == -1 )
            {
                var osignview = new AddIdeaViewModel
                {

                    TypesIdeas = fillselectTypeIDea()

                };
                TempData["messsages"] = "please chosee Idea Type";
                return View(osignview);

            }
            if (model.Fileidea !=null)
            {
                fileidea = UploadedFileidea(model);
            }
            var addideamodel = new Idea
            {
                ideaname = model.ideaname,
                descreption = model.descreption,
                Email = model.Email,
                Name = model.Name,
                phoneno = model.phoneno,
                Fileidea = fileidea != string.Empty ? fileidea : string.Empty

            };

            Iaddidea.Add(addideamodel);
            TempData["Message"] = "Add Idea Succsfuly";

            return RedirectToAction("AddIdea", "Idea");
        }
        public IActionResult InvestorAR()
        {
            var signview = new InvistorViewModel
            {
                Targetsectors = FillselectTarg()
            };
            return View(signview);
        }
        [HttpPost]
        public IActionResult InvestorAR(InvistorViewModel model)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");

            if (model.targetsecid == -1)
            {

                var osignview = new InvistorViewModel
                {
                    Targetsectors = FillselectTarg()
                };
                TempData["messsageserro"] = " يرجى تحديد المسار المتسهدف المناسب ";
                return View(osignview);
            }

            var targetfind = Itarget.Find(model.targetsecid);
            var idtarget = targetfind.TargetsectorID;

            var addinvistor = new Invistor
            {
                 CompanyName = model.CompanyName,
                TargetsectorID = idtarget,
                UserId=objComplex.Id,
                Flag=1
            };
            Iinvisto.Add(addinvistor);
            TempData["messsages"] = "تمت الإضافة بنجاح ";
            return RedirectToAction("InvestorAR", "Home");
        }
        [Authorize(Roles = BisnicityKey.InvistorRole)]
        public IActionResult InvestorEN()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            int flag = db.Invistor.Where(x => x.UserId == objComplex.Id).Select(x => x.Flag).FirstOrDefault();
            if(flag==1)
            {
                return RedirectToAction("", "");
            }
            else
            {
                var signview = new InvistorViewModel
                {
                    Targetsectors = FillselectTarg()
                };
                return View(signview);
            }
        }
           
        [HttpPost]
        public IActionResult InvestorEn(InvistorViewModel model)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");

            if (model.targetsecid == -1)
            {

                var osignview = new InvistorViewModel
                {
                    Targetsectors = FillselectTarg()
                };
                TempData["messsageserro"] = " يرجى تحديد المسار المتسهدف المناسب ";
                return View(osignview);
            }

            var targetfind = Itarget.Find(model.targetsecid);
            var idtarget = targetfind.TargetsectorID;

            var addinvistor = new Invistor
            {
                CompanyName = model.CompanyName,
                TargetsectorID = idtarget,
                UserId = objComplex.Id,
                Flag = 1

            };
            Iinvisto.Add(addinvistor);
            TempData["messsages"] = "تمت الإضافة بنجاح ";
            return RedirectToAction("", "");
        }
        [Authorize(Roles = BisnicityKey.SuportIdeaRole)]

        public IActionResult SupportIdea()
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");
            int flag = db.SuppourtIdea.Where(x => x.UserId == objComplex.Id).Select(x => x.Flag).FirstOrDefault();
            if(flag==1)
            {
                return RedirectToAction();
            }
            else
            {
                var signview = new SupportIdeaViewModel
                {

                    TypeCompanys = fillselect(),
                    Targetsectors = FillselectTarg()
                };
                return View(signview);
            }
           
        }
        [HttpPost]
        public IActionResult SupportIdea(SupportIdeaViewModel model)
        {
            var objComplex = HttpContext.Session.GetObject<ApplicationUser>("UserInfo");

            if (model.typecompid == -1 && model.targetsecid == -1)
            {

                var osignview = new SupportIdeaViewModel
                {
                    TypeCompanys = fillselect(),
                    Targetsectors = FillselectTarg()
                };
                TempData["messsages"] = "please chosee Target sector and TypeCompany ";
                return View(osignview);

            }
            string recod = string.Empty;
            string licence = string.Empty;
            string crt = string.Empty;
            var typefind = Itypecomp.Find(model.typecompid);
            int typecom = typefind.TypeCompanyID;
            var targetfind = Itarget.Find(model.targetsecid);
            var idtarget = targetfind.TargetsectorID;
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (model.Filerecord != null)
            {
                recod = UploadedFile1(model);
            }
            if (model.Filelicense != null)
            {
                licence = UploadedFile2(model);

            }
            if (model.Filecrt != null)
            {
                crt = UploadedFile3(model);

            }
            var addsupport = new SuppourtIdea
            {

                TargetsectorID = idtarget,
                TypeCompanyID = typecom,
                Commercialrecord = recod != string.Empty ? recod : string.Empty,
                CertificateofRegistration = crt != string.Empty ? crt : string.Empty,
                Careerslicense = licence != string.Empty ? licence : string.Empty,
                UserId = objComplex.Id,
                Flag = 1

            };
            Iaddsup.Add(addsupport);
            TempData["Message"] = "Add Support Idea Succsfuly";
            return RedirectToAction("", "");
        }
        public IActionResult DataPerson()
        {
            var dataperson = new DataPersonViewModel
            {
                Genders = fillselectgender(),
                Educationlevels = fillselectedu(),
                univircitys = FillselectUni()
            };
            return View(dataperson);
        }
        [HttpPost]
        public IActionResult DataPerson(DataPersonViewModel model)
        {
            if (model.levelID == -1 && model.genderID == -1 && model.uniID == -1)
            {

                var dataperson = new DataPersonViewModel
                {
                    Genders = fillselectgender(),
                    Educationlevels = fillselectedu(),
                    univircitys = FillselectUni()
                };
                TempData["messsages"] = "please chosee Gender and Level Educations and univircity";
                return View(dataperson);
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            var edufind = Iedu.Find(model.levelID);
            var genderfind = Igender.Find(model.genderID);
            var unifind = Iuni.Find(model.uniID);
            int genderid = genderfind.GenderID;
            int eduid = edufind.EducationlevelID;
            int uniID = unifind.UnivircityID;

            var addData = new DataPerson
            {
                Name = model.Name,
                Email = model.Email,
                phoneeNo = model.phoneeNo,
                GenderID = genderid,
                EducationlevelID = eduid,
                UnivircityID = uniID
            };
            Iadddataperson.Add(addData);


            return RedirectToAction("ShowTran", "Home", TempData["messsages"] = "Join Successfuly ");
        }

        #endregion

        #region Methods
        private string UploadedFileidea(AddIdeaViewModel model)
        {
            String FileExt = Path.GetExtension(model.Fileidea.FileName).ToUpper();
            string uniqueFileName = null;
            if (FileExt == ".PDF")
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "UploadsFileIdea");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Fileidea.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Fileidea.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }
        private string UploadedFile1(SupportIdeaViewModel model)
        {
            String FileExt = Path.GetExtension(model.Filerecord.FileName).ToUpper();
            string uniqueFileName = null;
            if (FileExt == ".PDF")
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "UploadsCommercialrecord");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Filerecord.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Filerecord.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }
        private string UploadedFile2(SupportIdeaViewModel model)
        {
            String FileExt = Path.GetExtension(model.Filelicense.FileName).ToUpper();
            string uniqueFileName = null;
            if (FileExt == ".PDF")
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "UploadsCareerslicense");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Filelicense.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Filelicense.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }

        private string UploadedFile3(SupportIdeaViewModel model)
        {
            String FileExt = Path.GetExtension(model.Filecrt.FileName).ToUpper();
            string uniqueFileName = null;
            if (FileExt == ".PDF")
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "UploadsCertificateofRegistration");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Filecrt.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Filecrt.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }
        #endregion
        #region List
        List<TypeIdea> fillselectTypeIDea()
        {
            var typeidealist = Itypeidea.List().ToList();
            typeidealist.Insert(0, new TypeIdea { TypeIdeaID = -1, NameType = "----please select an Type Idea------" });
            return typeidealist;

        }
        List<Targetsector> FillselectTarg()
        {
            var targlist = Itarget.List().ToList();
            targlist.Insert(0, new Targetsector { TargetsectorID = -1, namesector = "------ please select Target Sector" });
            return targlist;
        }
        List<TypeCompany> fillselect()
        {
            var typelist = Itypecomp.List().ToList();
            typelist.Insert(0, new TypeCompany { TypeCompanyID = -1, Typename = "----please select an Type Company------" });
            return typelist;

        }
        List<Gender> fillselectgender()
        {
            var genderlist = Igender.List().ToList();
            genderlist.Insert(0, new Gender { GenderID = -1, GenderName = "----please select Gender------" });
            return genderlist;

        }
        List<Educationlevel> fillselectedu()
        {
            var edulist = Iedu.List().ToList();
            edulist.Insert(0, new Educationlevel { EducationlevelID = -1, levelName = "----please select an Education Level------" });
            return edulist;

        }

        List<Univircity> FillselectUni()
        {
            var unilist = Iuni.List().ToList();
            unilist.Insert(0, new Univircity { UnivircityID = -1, UniName = "------ please select Univircity Name" });
            return unilist;
        }
        #endregion
    }
}
