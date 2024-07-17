#region NAMESPACES                          
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjeYonetimSistemi.UI.MVC.Models;
using System.Diagnostics;
#endregion

namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        #region FIELDS
        private readonly ILogger<HomeController> _logger;
        #endregion

        #region CTOR
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region ActionResults

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
#endregion

