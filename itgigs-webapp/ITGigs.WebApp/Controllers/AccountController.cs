using ITGigs.Common.Extensions;
using ITGigs.Common.Helpers;
using ITGigs.DB;
using ITGigs.LogService;
using ITGigs.LogService.Domain;
using ITGigs.UserService;
using ITGigs.UserService.Domain;
using ITGigs.UserService.Domain.Models;
using ITGigs.WebApp.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ITGigs.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IUser _userManager = new UserManager();
        private ILog _logger = Logger.GetInstance;
        private AppDbContext _ctx = new AppDbContext();

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public ActionResult ConfirmEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginEntry entry)
        {
            ViewData["WrongLogin"] = null;
            if (entry.Email == null || entry.Password == null)
            {
                ViewData["WrongLogin"] = "Incorrect form!";
                return View();
            }

            try
            {
                var user = await _userManager.GetUserByEmailAsync(entry.Email);
                if (user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        ViewData["WrongLogin"] = "Email is not confirmed!";
                        return View(entry);
                    }
                    if (HashUtils.VerifyPassword(entry.Password, user.Password))
                    {
                        return RedirectToAction("Index", "ITGigs");//redirect to user manager page
                    }
                }
            }
            catch (Exception ex)
            {
                await _logger.LogCustomExceptionAsync(ex, null);
                return RedirectToAction("Error", "Home");
            }

            ViewData["WrongLogin"] = "Incorrect username or password!";
            return View(entry);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterEntry entry)
        {
            ViewData["WrongRegister"] = null;
            try
            {
                User user = await _userManager.GetUserByEmailAsync(entry.Email);
                if (user != null)
                {
                    ViewData["WrongRegister"] = "Email already taken!";
                    return View(entry);
                }
                string password = HashUtils.CreateHashCode(entry.Password);
                string validationCode = HashUtils.CreateReferralCode();
                User newUser = new User(entry.Username, entry.Email, password, validationCode);

                await _userManager.RegisterAsync(newUser);
                //string appUrl = "http://localhost:55766/account/ValidateEmail";
                string appUrl = "https://itgigs.azurewebsites.net/account/ValidateEmail";
                string callbackUrl = $"{appUrl}?userId={newUser.Id}&validationCode={validationCode}";
                string link = $"<a href='{ callbackUrl}'>here</a>";

                await SendEmailAsync(entry.Email, "ITGigs registration request", $"To confirm your account click  -> {link}");
            }
            catch (Exception ex)
            {
                await _logger.LogCustomExceptionAsync(ex, null);
                return RedirectToAction("Error", "Home");
            }

            return View("Welcome");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ValidateEmail(string userId, string validationCode)
        {
            if (userId == null || validationCode == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            try
            {
                User user = await _userManager.GetUserByIdAsync(userId);
                if (user == null || validationCode.ToLower().Trim() != user.ValidationCode.ToLower().Trim())
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                user = UpdateUser(user);
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

        private async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("your-name@gmail.com", "your-pass@")
                };

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("whoever@me.com");
                mailMessage.To.Add(email);
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = subject;
                client.EnableSsl = true;
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                await _logger.LogCustomExceptionAsync(ex, null);
                throw new ApplicationException($"Unable to load : '{ex.Message}'.");
            }
        }

        private User UpdateUser(User user)
        {
            var updatedUser = new User(
                user.Username,
                user.Email,
                user.Password,
                user.ValidationCode,
                true,
                new CustomId(new Guid(user.Id)),
                user.ImgUrl,
                DateTime.Now
            );
            return updatedUser;
        }
    }
}