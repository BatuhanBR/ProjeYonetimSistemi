using Microsoft.AspNetCore.Mvc;
using ProjeYonetimSistemi.UI.MVC.Context;
using ProjeYonetimSistemi.UI.MVC.Models;


namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

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
        [HttpGet]
        public IActionResult AddProject()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProject(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }


    }

}
