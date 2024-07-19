#region NAMESPACES
using Microsoft.AspNetCore.Mvc;

#endregion

namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
    public class UserController : Controller
    {

        #region ACTION RESULTS
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        #endregion


    }
}
