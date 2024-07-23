#region NAMESPACES
using Microsoft.AspNetCore.Mvc;
#endregion 

namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
    public class TeamController : Controller
    {
        #region FIELDS

        #endregion

        #region CTOR
        public TeamController()
        {
                
        }

        #endregion

        #region ACTION RESULTS

        public IActionResult Index()
        {
            return View();
        }
        #endregion

    }
}
