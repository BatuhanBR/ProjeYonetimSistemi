#region NAMESPACES
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Detail(int id)
        {
            var project = _context.Projects
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.ProjectName,
                    p.Description
                })
                .FirstOrDefault();

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
        public async Task<IActionResult> Update(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ProjectEntity updatedProject)
        {
            if (id != updatedProject.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updatedProject);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(updatedProject.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(updatedProject);
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id); // Burada Projects kullanılıyor.
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
