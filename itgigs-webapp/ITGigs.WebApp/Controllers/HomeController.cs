using ITGigs.DB;
using ITGigs.LogService;
using ITGigs.LogService.Domain;
using ITGigs.LogService.Domain.Models;
using ITGigs.UserService.Domain.Models;
using ITGigs.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ITGigs.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private bool _isSignedIn;
        private ILog _logger = Logger.GetInstance;
        private AppDbContext _ctx = new AppDbContext();
        public HomeController()
        {
            _isSignedIn = false;// HttpContext.Session.GetObjectFromJson<string>("IsSignedIn");           
        }
        public async Task<IActionResult> Index()
        {
            ViewData["IsSignedIn"] = _isSignedIn;
            return View();
        }

        public IActionResult Error()
        {
            ViewData["IsSignedIn"] = _isSignedIn;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> AllUsers()
        {
            List<User> users = null;
            try
            {
                users = _ctx.Users
                    .OrderByDescending(u => u.DateCreated)
                    .ToList();
            }
            catch (Exception ex)
            {
                await _logger.LogCustomExceptionAsync(ex, null);
            }

            ViewData["IsSignedIn"] = _isSignedIn;
            return View(users);
        }

        public async Task<IActionResult> AllExceptions()
        {
            List<CustomException> exceptions = null;
            try
            {
                exceptions = _ctx.CustomExceptions
                    .OrderByDescending(e => e.DateCreated)
                    .Take(5)
                    .ToList();
            }
            catch (Exception ex)
            {
                await _logger.LogCustomExceptionAsync(ex, null);
            }
            ViewData["IsSignedIn"] = _isSignedIn;
            return View(exceptions);
        }
    }
}
