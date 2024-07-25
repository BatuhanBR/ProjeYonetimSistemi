#region NAMESPACES
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeYonetimSistemi.UI.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

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
            var users = _userManager.Users.ToList();
            var userRoles = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.Count > 0 ? roles[0] : "Rol Bilinmiyor";
                userRoles.Add(new UserRoleViewModel
                {
                    User = user,
                    Role = role
                });
            }

            return View(userRoles);
        }

        public IActionResult Detail()
        {
            return View();
        }

        public async Task<IActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new UpdateUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.Email = model.Email;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
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
                LastName = user.LastName,
                Email = user.Email
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
            // Mevcut kullanıcıları listele
            var users = _userManager.Users.ToList();
            ViewBag.Users = users; // Kullanıcıları ViewBag ile geçiyoruz
            return View();
        }

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
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

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

            // Model geçersizse, kullanıcı listesini yeniden yükleyin
            ViewBag.Users = _userManager.Users.ToList();
            return View(model);
        }

        #endregion
    }
}
