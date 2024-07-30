
#region NAMESPACES
using Microsoft.AspNetCore.Mvc;
#endregion

namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
        #region CTOR
    public class ReportController : Controller
    {
        #endregion

        #region Action Results
        public IActionResult Index()
        {
            return View();
        }
        #endregion
    }
}
