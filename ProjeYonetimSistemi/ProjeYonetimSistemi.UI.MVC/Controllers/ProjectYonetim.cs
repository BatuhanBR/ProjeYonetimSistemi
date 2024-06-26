using Microsoft.AspNetCore.Mvc;

namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
    public class Project : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
