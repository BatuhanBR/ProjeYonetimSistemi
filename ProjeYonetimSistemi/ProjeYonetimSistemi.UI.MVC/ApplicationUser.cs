using Microsoft.AspNetCore.Identity;

namespace ProjeYonetimSistemi.UI.MVC
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
