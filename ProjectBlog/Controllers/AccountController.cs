using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectBlog.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectBlog.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext c)
        {
            _context = c;
        }

        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var getX = HttpContext.User.Identity.Name;
                var getAcc = _context.Access.Where(x => x.Username == getX)
                       .Include(x => x.Role).FirstOrDefault();

                if (getAcc.Role != null)                          
                {
                    return Redirect($"/{getAcc.Role.Name}/");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Username, Password")] AccessUser AccUser)
        {
            var getAcc = _context.Access.Where(x => x.Username == AccUser.Username && x.Password == AccUser.Password)
                        .Include(x => x.Role).FirstOrDefault();

            if (getAcc != null)
            {
                var Claims = new List<Claim>
                {
                    new Claim("username",getAcc.Username),
                    new Claim("role", getAcc.Role.Name)
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(
                    new ClaimsIdentity(Claims, "Cookies", "username","role")
                    ));

                if (getAcc.Role != null)                            //Role banyak, recommended
                {
                    return Redirect($"/{getAcc.Role.Name}/");
                }

                return Redirect("/Home");

                //if (getAcc.Id == 1)                               //Untu Role yang sedikit
                //{
                //    return Redirect("Admin/Blog");
                //}
                //else if (getAcc.Id == 2)
                //{
                //    return Redirect("User/BlogContent");
                //}
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Denied()
        {
            return View();
        }

        public IActionResult Register()
        {
            var getRoles = _context.Role.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            ViewBag.SelectListRole = getRoles;
            return View();
        }

        [HttpPost]
        public IActionResult Register([Bind("Id,Username,Name,Password,Role")] UserForm UserRegis)
        {
            if (ModelState.IsValid)
            {
                var getData = new Access
                {
                    Username = UserRegis.Username,
                    Name = UserRegis.Name,
                    Password = UserRegis.Password,
                    Role = _context.Role.FirstOrDefault(x => x.Id == UserRegis.Role)
                };

               
                _context.Add(getData);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            var getRoles = _context.Role.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            ViewBag.SelectListRole = getRoles;

            return View();
        }

    }
}
