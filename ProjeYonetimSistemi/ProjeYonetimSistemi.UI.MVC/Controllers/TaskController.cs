using Microsoft.AspNetCore.Mvc;

namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
