using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PriceParser.Web.Models;
using System.Security.Claims;

namespace PriceParser.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel { ReturnUrl = "/Home/Index"});
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Пользователь не найден");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                Redirect(model.ReturnUrl);
            }

            ModelState.AddModelError("", "Неверный пароль");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel { ReturnUrl = "/Home/Index"});
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!model.IsAdult)
            {
                ModelState.AddModelError("", "Регистрация доступна только совершеннолетним пользователям");
                return View(model);
            }
            if(await userManager.FindByNameAsync(model.UserName) != null)
            {
                ModelState.AddModelError("", "Такой пользователь уже зарегестрирован");
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);

                await userManager.AddClaimAsync(user, new Claim("IsAdult", model.IsAdult.ToString()));

                return Redirect(model.ReturnUrl);
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}
