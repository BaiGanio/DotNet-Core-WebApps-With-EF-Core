using ITGigs.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ITGigs.WebApp.Controllers
{
    public class ManageController : Controller
    {
        private string _userId;
        private string _username;

        public IActionResult Index()
        {
            _userId = HttpContext.Session.GetObjectFromJson<string>("UserId");
            if (_userId == null) return RedirectToAction("AccessDenied", "Home");
            _username = HttpContext.Session.GetObjectFromJson<string>("UserName");
            ViewData["UserId"] = _userId;
            ViewData["UserName"] = _username;
            return View();
        }
    }
}