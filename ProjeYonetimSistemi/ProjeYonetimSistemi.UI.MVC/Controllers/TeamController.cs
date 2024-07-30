#region NAMESPACES
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeYonetimSistemi.UI.MVC.Context;
using ProjeYonetimSistemi.UI.MVC.Entity;
using ProjeYonetimSistemi.UI.MVC.ViewModels;
#endregion

namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
        
    public class TeamController : Controller
    {
        #region FİELDS
        private readonly ApplicationDbContext _context;
        #endregion

        #region CTOR
        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Action Results
        // Ekip üyelerini ve takımları listelemek için Index metodu
        public async Task<IActionResult> Index()
        {
            var teams = await _context.Teams.ToListAsync();
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamEntity team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        public IActionResult AddMember()
        {
            var viewModel = new AddTeamMemberViewModel
            {
                JobTitles = _context.JobTitles.Select(j => new SelectListItem
                {
                    Value = j.JobTitleId.ToString(),
                    Text = j.JobName
                }).ToList(),
                // Diğer gerekli veriler
            };

            return View(viewModel);
        }

        // POST: Team/AddMember
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMember(AddTeamMemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var teamMember = new TeamMemberEntity
                {
                    TeamId = model.TeamId,
                    Name = model.Name,
                    SurName = model.SurName,
                    JobTitleId = model.JobTitleId
                };

                _context.TeamMembers.Add(teamMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            model.JobTitles = _context.JobTitles.Select(j => new SelectListItem
            {
                Value = j.JobTitleId.ToString(),
                Text = j.JobName
            }).ToList();

            return View(model);
        }

        // JobTitles tablosuna veri eklemek için SeedJobTitles metodu
        public IActionResult SeedJobTitles()
        {

            if (!_context.JobTitles.Any())
            {
                var jobTitles = new JobTitle[]
                {
                    new JobTitle { JobName = "Yazılım Geliştirici" },
                    new JobTitle { JobName = "Sistem Analisti" },
                    new JobTitle { JobName = "Proje Yöneticisi" }
                };

                _context.JobTitles.AddRange(jobTitles);
                _context.SaveChanges();
            }

            return Content("İş unvanları başarıyla eklendi.");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamId == id);

            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }

            TempData["Message"] = "Takım başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
           
                .FirstOrDefaultAsync(m => m.TeamId == id);

            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Team/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Team/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeamEntity team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }


    }
}
#endregion