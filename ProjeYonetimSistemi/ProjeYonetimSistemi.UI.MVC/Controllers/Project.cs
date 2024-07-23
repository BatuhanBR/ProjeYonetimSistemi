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

        public async Task<IActionResult> Detail(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> UpdateProject(ProjectEntity updatedProject)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);  // Hataları konsola yazdırın
                }
                return View(updatedProject);
            }

            try
            {
                var existingProject = await _context.Projects.FindAsync(updatedProject.Id);
                if (existingProject == null)
                {
                    return NotFound();
                }

                existingProject.ProjectName = updatedProject.ProjectName;
                existingProject.TeamMembers = updatedProject.TeamMembers;
                existingProject.Description = updatedProject.Description;
                existingProject.CreatedDate = updatedProject.CreatedDate;

                _context.Projects.Update(existingProject);
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

      


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
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
        public async Task<IActionResult> AddProject(ProjectEntity project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
