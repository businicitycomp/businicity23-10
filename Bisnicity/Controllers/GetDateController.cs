/*************************************************************************************************************/
/*Class Name    : GetDateController.cs                                                                       /
/*Created By    : samer sami                                                                            */
/*Ceation Date  :                                                                            */
/******************************************************************************************************/
using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using Infrastrucer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GetDateController : ControllerBase
    {
        #region Members
        //private readonly IBisnicity<Info> Info;
        //private readonly IBisnicity<OurServices> ourserv;
        //private readonly IBisnicity<Services> serv;
        //private readonly IBisnicity<Templete> Temp;
        private readonly IStringLocalizer<GetDateController> stringLocalizer;
        private readonly DataContext db;
        public GetDateController(/*IBisnicity<Info> bisnicity, IBisnicity<OurServices> _ourserv, IBisnicity<Services> _serv, IBisnicity<Templete> _Temp,*/ 
            DataContext _db, IStringLocalizer<GetDateController> _stringLocalizer)
        {
            //Info = bisnicity;
            //ourserv = _ourserv;
            //serv = _serv;
            //Temp = _Temp;
            db = _db;
            stringLocalizer = _stringLocalizer;
        }
        #endregion

        #region Api
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(stringLocalizer["welcome"].Value);
        }
       
        [HttpGet("{id}")]
        //public IActionResult Getinfo(int id)
        //{
        //    List<Info> getinfo = this.Info.List().Where(x => x.InfoID.Equals(id)).ToList();

        //    return Ok(new RespoancDTO<Info>
        //    {
        //        Data = getinfo.ToList(),
        //        Erros = new List<string>() { },
        //        Messages = "done"
        //    }); 
        //}

        [HttpGet("{id}")]
        //public IActionResult GetOurserv(int id)
        //{
        //    List<OurServices> getourserv = this.ourserv.List().Where(x => x.InfoID.Equals(id)).ToList();

        //    return Ok(new RespoancDTO<OurServices>
        //    {
        //        Data = getourserv.ToList(),
        //        Erros = new List<string>() { },
        //        Messages = "done"
        //    });
        //}
        [HttpGet("{id}")]
        //public IActionResult GetService(int id)
        //{
        //    List<Services> getserv = this.serv.List().Where(x => x.InfoID.Equals(id)).ToList();

        //    return Ok(new RespoancDTO<Services>
        //    {
        //        Data = getserv.ToList(),
        //        Erros = new List<string>() { },
        //        Messages = "done"
        //    });
        //}

        [HttpGet("{id}")]
        //public IActionResult GetTemp(int id)
        //{
        //    List<Templete> gettemp = this.Temp.List().Where(x => x.InfoID.Equals(id)).ToList();

        //    return Ok(new RespoancDTO<Templete>
        //    {
        //        Data = gettemp.ToList(),
        //        Erros = new List<string>() { },
        //        Messages = "done"
        //    });
        //}

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var job = db.jobVacancy.Where(x => x.JobType.Contains(term)).Select(x => x.JobType).ToList();
                return Ok(job);
            }
            catch
            {
                return BadRequest();
            }

        }

        [Produces("application/json")]
        [HttpGet("search2")]
        public async Task<IActionResult> Search2()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var job = db.Person.Where(x => x.Major.Contains(term)).Select(x => x.Major).ToList();
                return Ok(job);
            }
            catch
            {
                return BadRequest();
            }

        }
        #endregion
    }
    #region Respnse
    public class RespoancDTO<T>
    {
        public List<T> Data { get; set; }
        public string Messages { get; set; }
        public List<string> Erros { get; set; }
    }

    #endregion
}
