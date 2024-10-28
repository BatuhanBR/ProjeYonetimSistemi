#region NAMESPACES
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeYonetimSistemi.UI.MVC.Context;
using ProjeYonetimSistemi.UI.MVC.Dto.Task;
using ProjeYonetimSistemi.UI.MVC.Entity;
#endregion

namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
    public class TaskController : Controller
    {
        #region FIELDS
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public TaskController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region ACTION RESULTS
        public async Task<IActionResult> Index()
        {
            var tasks = await _context.Tasks
 
                .ToListAsync();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Projeleri al ve ViewBag'e ekle
            var projects = _context.Projects
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.ProjectName
                }).ToList();
            ViewBag.Projects = projects;

            // Durum seçeneklerini ViewBag'e ekle
            ViewBag.Statuses = new List<SelectListItem>
    {
        new SelectListItem { Value = "Başlanmadı", Text = "Başlanmadı" },
        new SelectListItem { Value = "Devam Ediyor", Text = "Devam Ediyor" },
        new SelectListItem { Value = "Tamamlandı", Text = "Tamamlandı" }
    };

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(addTaskDto taskDto)
        {
           
                var taskEntity = _mapper.Map<TaskEntity>(taskDto);
                _context.Tasks.Add(taskEntity);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
          

 

        
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            var projects = _context.Projects
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.ProjectName
                }).ToList();
            ViewBag.Projects = projects;

            var model = new UpdateTaskDto
            {
                TaskId = task.Id,
                TaskName = task.TaskName,
                Description = task.Description,
                ProjectId = task.ProjectId,
                Progress = task.Progress,
                Status = task.Status,
                CreatedDate = task.CreatedDate
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateTaskDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                // ModelState hatalarını kontrol edin ve projeleri tekrar yükleyin
                var projects = _context.Projects
                    .Select(p => new SelectListItem
                    {
                        Value = p.Id.ToString(),
                        Text = p.ProjectName
                    }).ToList();
                ViewBag.Projects = projects;

                return View(taskDto);
            }

            var task = await _context.Tasks.FindAsync(taskDto.TaskId);
            if (task == null)
            {
                return NotFound();
            }

            _mapper.Map(taskDto, task);

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            var task = _context.Tasks.Include(t => t.ProjectId).FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }
        #endregion
    }
}
