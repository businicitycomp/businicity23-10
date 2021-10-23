/*************************************************************************************************************/
/*Class Name    : BaseController.cs                                                                       /
/*Created By    : Hamza Nayef                                                                             */
/*Ceation Date  : 09-10-2021                                                                            */
/******************************************************************************************************/
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Bisnicity.Controllers
{
    public class BaseController : Controller
    {
        #region Action ::CustomRedirect
        public async Task<IActionResult> CustomRedirect(string sActionName, string sConntrolr)
        {
            if (!string.IsNullOrEmpty(sConntrolr) && !string.IsNullOrEmpty(sActionName))
            {
                return RedirectToAction(sActionName, sConntrolr);
            }
            return RedirectToAction();
        }
        #endregion
    }
}
