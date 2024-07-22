#region NAMESPACES
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeYonetimSistemi.UI.MVC.Models;

#endregion

namespace ProjeYonetimSistemi.UI.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        #region ACTION RESULTS
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList(); // Kullanıcıları çek
            var model = new CreateUserViewModel
            {
                Users = users
            };
            return View(model);
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new CreateUserViewModel
            {
                
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(new CreateUserViewModel { FirstName = user.FirstName, LastName = user.LastName });
        }

        public IActionResult Create()
        {
            var users = _userManager.Users.ToList();
            var model = new CreateUserViewModel
            {
                Users = users
            };
            return View(model);
        }

        // POST: /User/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email // Kullanıcı adı olarak e-posta kullanıyoruz
                };

                var result = await _userManager.CreateAsync(user, model.Password); // Şifreyi ekliyoruz

                if (result.Succeeded)
                {
                    // Kullanıcı başarıyla eklendiğinde yapılacak işlemler
                    return RedirectToAction("Index");
                }

                // Hata durumunda model state'e hata ekleyin
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            // Model geçersizse, mevcut kullanıcıları ve model bilgilerini yeniden yükleyin
            var users = _userManager.Users.ToList();
            model.Users = users;
            return View(model);
        }

        #endregion


    }
}
