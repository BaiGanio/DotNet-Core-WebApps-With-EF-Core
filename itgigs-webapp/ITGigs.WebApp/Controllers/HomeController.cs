using ITGigs.DB;
using ITGigs.LogService;
using ITGigs.LogService.Domain;
using ITGigs.LogService.Domain.Models;
using ITGigs.UserService.Domain.Models;
using ITGigs.WebApp.Extensions;
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
        #region Private Fields

        private string _userId;
        private string _username;
        private string _imgUrl;
        private ILog _logger = Logger.GetInstance;
        private AppDbContext _ctx = new AppDbContext();

        #endregion

        public HomeController() { }

        public IActionResult Index()
        {
            _userId = HttpContext.Session.GetObjectFromJson<string>("UserId");
            _username = HttpContext.Session.GetObjectFromJson<string>("UserName");
            _imgUrl = HttpContext.Session.GetObjectFromJson<string>("ImgUrl");
            ViewData["UserId"] = _userId;
            ViewData["UserName"] = _username;
            ViewData["ImgUrl"] = _imgUrl;
            return View();
        }

        public IActionResult Error()
        {
            ViewData["UserId"] = _userId;
            ViewData["UserName"] = _username;
            ViewData["ImgUrl"] = _imgUrl;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AccessDenied()
        {
            return View();
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

            ViewData["IsSignedIn"] = _userId;
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
            ViewData["IsSignedIn"] = _userId;
            return View(exceptions);
        }
    }
}
