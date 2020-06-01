using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.DTO.Account;
using MyBlog.BLL.Interfaces;
using MyBlog.BLL.Interfaces.Account;
using MyBlog.Web.ViewModel;

namespace MyBlog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRoleService roleService;
        private readonly IUserService userService;

        public AccountController(IRoleService roleService, IUserService userService)
        {
            this.roleService = roleService;
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = userService
                    .GetAll()
                    .FirstOrDefault(user => user.Email == model.Email || user.Login == model.Login);
                if (user == null)
                {
                    user = new UserDTO
                    {
                        Login = model.Login,
                        Email = model.Email,
                        Password = model.Password,
                        RoleDTOId = 2, // user по умолчанию
                        RoleDTO = new RoleDTO { Name = "user" }
                    };

                    userService.Create(user);

                    await Authenticate(user);

                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    ModelState.AddModelError("", "Неправльные данные");
                }
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
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = userService
                    .GetAll()
                    .FirstOrDefault(u => (u.Login == model.Login || u.Email == model.Login) && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Blog");
                }
                ModelState.AddModelError("", "Неверные данные");
            }
            return View("Login", model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleDTO?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public IActionResult Role()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Role(RoleDTO roleDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(roleDTO);
            }
            roleService.Create(roleDTO);
            return View();
        }
    }
}