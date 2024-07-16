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

        #region ACTIN REULSTS
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
                var taskEntity = _mapper.Map<TaskEntity>(model);
                // taskEntity nesnesini veritabanına kaydet
                // _context.Tasks.Add(taskEntity);
                // _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
