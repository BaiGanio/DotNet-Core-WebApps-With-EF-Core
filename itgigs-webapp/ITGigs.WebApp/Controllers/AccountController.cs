using ITGigs.Common.Helpers;
using ITGigs.UserService;
using ITGigs.UserService.Domain;
using ITGigs.UserService.Domain.Models;
using ITGigs.WebApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ITGigs.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IUser _userManager = new UserManager();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginEntry entry)
        {
            ViewData["WrongLogin"] = null;
            var users = await _userManager.GetAllUsersAsync();
            var user = users.FirstOrDefault(u => u.Username == entry.Username.Trim());
            if (user != null)
            {
                if (HashUtils.VerifyPassword(entry.Password, user.Password))
                {
                    return RedirectToAction("Index", "ITGigs");
                }
            }
            ViewData["WrongLogin"] = "Incorrect username or password!";
            return View(entry);
        }

        // Get
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterEntry entry)
        {
            ViewData["WrongRegister"] = null;
            if (entry.Username == null || entry.Password == null || entry.Email == null)
            {
                ViewData["WrongRegister"] = "Incorrect form!";
                return View();
            }
            try
            {
                User user = await _userManager.GetUserByEmailAsync(entry.Email);
                if (user != null)
                {
                    ViewData["WrongRegister"] = "Email already taken!";
                    return View();
                }
                string password = HashUtils.CreateHashCode(entry.Password);
                User newuser = new User(entry.Username, entry.Email, password, entry.ImgUrl);
                await _userManager.RegisterAsync(newuser);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "ITGigs"); // Error page
            }

            return RedirectToAction("AllUsers", "Home");
        }

    }
}