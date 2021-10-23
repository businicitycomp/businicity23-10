using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisnicity.Controllers.Api
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IStringLocalizer<LanguageController> sLocalizer;
        public LanguageController(IStringLocalizer<LanguageController> _sLocalizer)
        {
            sLocalizer = _sLocalizer;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(sLocalizer["welcome"]);
        }
    }
}
