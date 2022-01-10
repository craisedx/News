using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using News.Models;
using News.ViewModels;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStringLocalizer<AccountController> localizer;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(
            IStringLocalizer<AccountController> localizer, 
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.localizer = localizer;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "News");
                }

                foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await signInManager
                    .PasswordSignInAsync(model.Email, model.Password, true, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "News");
                }

                ModelState.AddModelError("", localizer["IncorrectNameOrPassword"]);
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "News");
        }
    }
}
