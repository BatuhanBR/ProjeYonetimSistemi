using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjeYonetimSistemi.UI.MVC.Context;
using ProjeYonetimSistemi.UI.MVC.Entity;

public class ProjectController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProjectController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(string status)
    {
        IQueryable<ProjectEntity> projects = _context.Projects.Include(p => p.TeamEntity).OrderByDescending(x => x.Id);

        if (status == "active")
        {
            projects = projects.Where(p => p.IsActive);
        }
        else if (status == "passive")
        {
            projects = projects.Where(p => !p.IsActive);
        }

        return View(await projects.ToListAsync());
    }

    public async Task<IActionResult> Detail(int id)
    {
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
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

        ViewBag.Teams = new SelectList(await _context.Teams.ToListAsync(), "TeamId", "TeamName");
        return View(project);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProjectEntity updatedProject)  // Method adı UpdateProject'ten Edit'e değiştirildi
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Teams = new SelectList(await _context.Teams.ToListAsync(), "TeamId", "TeamName", updatedProject.TeamId);
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
            existingProject.TeamId = updatedProject.TeamId;
            existingProject.Description = updatedProject.Description;
            existingProject.CreatedDate = updatedProject.CreatedDate;
            existingProject.IsActive = updatedProject.IsActive;

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
    public async Task<IActionResult> AddProject()
    {
        ViewBag.Teams = new SelectList(await _context.Teams.ToListAsync(), "TeamId", "TeamName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProject(ProjectEntity project)
    {

        project.TeamEntity =   _context.Teams.FirstOrDefault(x=>x.TeamId == project.TeamId);

        

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProjectExists(int id)
    {
        return _context.Projects.Any(e => e.Id == id);
    }
}
