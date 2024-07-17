#region NAMESPACES
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private object model;
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
            var tasks = await _context.Tasks.ToListAsync();
            return View(tasks);
        }

        public IActionResult Create()
        {
            var projects = _context.Projects.ToList();
            ViewBag.Projects = projects;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(addTaskDto task)
        {
            if (ModelState.IsValid)
            {
                var taskEntity = _mapper.Map<TaskEntity>(task);
                // taskEntity nesnesini veritabanına kaydet
                _context.Tasks.Add(taskEntity);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
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

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound(); 
            }
            return View(task);
        }
        #endregion

    }
}
