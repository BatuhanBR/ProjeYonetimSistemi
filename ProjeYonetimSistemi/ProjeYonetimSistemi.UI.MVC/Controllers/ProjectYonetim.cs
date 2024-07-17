#region NAMESPACES
using Microsoft.AspNetCore.Mvc;
using ProjeYonetimSistemi.UI.MVC.Context;
using ProjeYonetimSistemi.UI.MVC.Entity;

#endregion


namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
    public class ProjectController : Controller
    {
        #region FIELDS
        private readonly ApplicationDbContext _context;

        #endregion

        #region CTOR
        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion


        public IActionResult Index()
        {
            var result = _context.Projects.ToList();

            return View(result);
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
        public IActionResult AddProject(ProjectEntity project)
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
