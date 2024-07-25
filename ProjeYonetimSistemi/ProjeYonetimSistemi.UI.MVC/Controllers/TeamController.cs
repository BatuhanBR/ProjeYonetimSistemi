using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjeYonetimSistemi.UI.MVC.Entity; // Projenizin model sınıfları ve context'ini içeren namespace
using System.Threading.Tasks;
using ProjeYonetimSistemi.UI.MVC.Context;
using ProjeYonetimSistemi.UI.MVC.Models;

using Microsoft.AspNetCore.Mvc.Rendering;
using ProjeYonetimSistemi.UI.MVC.ViewModels;

namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Ekip üyelerini ve takımları listelemek için Index metodu
        public async Task<IActionResult> Index()
        {
            var teams = await _context.Teams.Include(t => t.TeamMembers).ToListAsync();
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamEntity team) // Teams yerine TeamEntity
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
    }
}

