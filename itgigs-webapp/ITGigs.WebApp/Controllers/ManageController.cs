using ITGigs.UserService.Domain.Models;
using ITGigs.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ITGigs.WebApp.Controllers
{
    public class ManageController : Controller
    {
        private string _userId;
        private string _username;
        private TypeOfUser _typeOfUser;

        public IActionResult Index()
        {
            _userId = HttpContext.Session.GetObjectFromJson<string>("UserId");
            if (_userId == null) return RedirectToAction("AccessDenied", "Home");
            _username = HttpContext.Session.GetObjectFromJson<string>("UserName");
            _typeOfUser = HttpContext.Session.GetObjectFromJson<TypeOfUser>("TypeOfUser");
            ViewData["UserId"] = _userId;
            ViewData["UserName"] = _username;                                        
            ViewData["TypeOfUser"] = _typeOfUser;
            return View();
        }
    }
}