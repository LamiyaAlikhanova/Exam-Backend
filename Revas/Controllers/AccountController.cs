using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Revas.Models;
using Revas.ViewModel.Account;

namespace Revas.Controllers
{
    [Area("Mnage")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManagere;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User>userManager, SignInManager<User>signinManagere, RoleManager<IdentityRole>roleManager)
        {
            _userManager = userManager;
            _signinManagere = signinManagere;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid) 
            { 
                return View();
            }
            User user = new User
            {
                Name = registerVm.Name,
                Surname = registerVm.Surname,
                UserName = registerVm.UserName,
                Email = registerVm.Email,
            };

            return View(registerVm);

        }

       
    }
}
