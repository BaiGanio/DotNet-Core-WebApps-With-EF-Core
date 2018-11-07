using ITGigs.Common.Extensions;
using ITGigs.DB;
using ITGigs.LogService;
using ITGigs.LogService.Domain;
using ITGigs.NotificationService;
using ITGigs.NotificationService.Domain;
using ITGigs.UserService;
using ITGigs.UserService.Domain;
using ITGigs.UserService.Domain.Models;
using ITGigs.WebApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ITGigs.WebApp.Controllers
{
    public class ManageController : Controller
    {
        #region PrivateFields

        private string _userId;
        private string _username;
        private TypeOfUser _typeOfUser;

        private ILog _logger = Logger.GetInstance;
        private INotificationActor _notificationManager = new NotificationManager();
        private IUser _userManager = new UserManager();

        private AppDbContext _ctx = new AppDbContext();

        #endregion

        public IActionResult Index(string customMessage = null)
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<string>("UserId");
            // no real user is behind this request - no chance to go further
            if (ViewData["UserId"] == null) return RedirectToAction("AccessDenied", "Home");

            ViewData["UserName"] = HttpContext.Session.GetObjectFromJson<string>("UserName");
            ViewData["TypeOfUser"] = HttpContext.Session.GetObjectFromJson<TypeOfUser>("TypeOfUser");
            return View();
        }

        public IActionResult PerformerRequest()
        {
            //ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<string>("UserId");
            //if (ViewData["UserId"] == null) return RedirectToAction("AccessDenied", "Home");
            //try
            //{
            //    //var user = await _userManager.GetUserByIdAsync(ViewData["UserId"].ToString());
            //    //await _notificationManager.SendPerformerRequestEmailAsync(user);
            //}
            //catch (Exception ex)
            //{
            //    //await _logger.LogCustomExceptionAsync(ex, null);
            //    //return RedirectToAction("Error", "Home");
            //}
            return View();
        }

        public IActionResult VenueOwnerRequest()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            _userId = HttpContext.Session.GetObjectFromJson<string>("UserId");
            // no real user is behind this request - no chance to go further
            if (_userId == null) return RedirectToAction("AccessDenied", "Home");
            _username = HttpContext.Session.GetObjectFromJson<string>("UserName");
            _typeOfUser = HttpContext.Session.GetObjectFromJson<TypeOfUser>("TypeOfUser");
            ViewData["UserId"] = _userId;
            ViewData["UserName"] = _username;
            ViewData["TypeOfUser"] = _typeOfUser;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> PerformerRequest(string userId, string validationCode)
        {
            if (userId == null || validationCode == null)
            {
                return View("AccessDenied");
                // return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            try
            {
                User user = await _userManager.GetUserByIdAsync(userId);
                if (user == null || validationCode != user.ValidationCode)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                user = UpdatePerformerUserType(user);
                _ctx.Update(user);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _logger.LogCustomExceptionAsync(ex, null);
                return RedirectToAction("Error", "Home");
            }

            HttpContext.Session.SetObjectAsJson<string>("CustomMessage", "Request accepted. Check your email for confirmation link");
            return View(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> VenueOwnerRequest(string userId, string validationCode)
        {
            if (userId == null || validationCode == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            try
            {
                User user = await _userManager.GetUserByIdAsync(userId);
                if (user == null || validationCode != user.ValidationCode)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                user = UpdateVenueOwnerUserType(user);
                _ctx.Update(user);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _logger.LogCustomExceptionAsync(ex, null);
                return RedirectToAction("Error", "Home");
            }
            return View("ConfirmEmail");
        }

        #region PrivateMethods

        private User UpdatePerformerUserType(User user)
        {
            var updatedUser = new User(
                user.Username,
                user.Email,
                user.Password,
                TypeOfUser.Performer,
                user.ValidationCode,
                user.IsEmailConfirmed,
                new CustomId(new Guid(user.Id)),
                user.ImgUrl,
                DateTime.Now
            );
            return updatedUser;
        }

        private User UpdateVenueOwnerUserType(User user)
        {
            var updatedUser = new User(
                user.Username,
                user.Email,
                user.Password,
                TypeOfUser.VenueOwner,
                user.ValidationCode,
                user.IsEmailConfirmed,
                new CustomId(new Guid(user.Id)),
                user.ImgUrl,
                DateTime.Now
            );
            return updatedUser;
        }

        #endregion

    }
}