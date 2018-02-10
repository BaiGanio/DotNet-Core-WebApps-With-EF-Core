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
            var users = await _userManager.GetAllUsersAsync();
            var user = users.FirstOrDefault(u => u.Username == entry.Username);
            if (user != null)
            {
                if (HashUtils.VerifyPassword(entry.Password, user.Password))
                {
                    return RedirectToAction("Index", "ITGigs");
                }
            }
            ViewData["WrongLogin"] = "Ей шибаняк, вкарвай коректни данни!";
            return View(entry);
        }

        // Get
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterEntry entry)
        {
            try
            {
                string password = HashUtils.CreateHashCode(entry.Password);
                User user = new User(entry.Username, entry.Email, password, entry.ImgUrl);
                await _userManager.RegisterAsync(user);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "ITGigs"); // Error page
            }

            return RedirectToAction("AllUsers", "Home");
        }

    }
}