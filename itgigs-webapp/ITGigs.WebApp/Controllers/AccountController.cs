using ITGigs.Common.Helpers;
using ITGigs.UserService;
using ITGigs.UserService.Domain;
using ITGigs.UserService.Domain.Models;
using ITGigs.WebApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public IActionResult Welcome()
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
            if (entry.Username == null || entry.Password == null)
            {
                ViewData["WrongLogin"] = "Incorrect form!";
                return View();
            }

            try
            {
                var users = await _userManager.GetAllUsersAsync();
                var user = users.FirstOrDefault(u => u.Username == entry.Username.Trim());
                if (user != null)
                {
                    if (HashUtils.VerifyPassword(entry.Password, user.Password))
                    {
                        return RedirectToAction("Index", "ITGigs");//redirect to user manager page
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: log the error
                return RedirectToAction("Index", "ITGigs"); // Error page
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
                var callbackUrl = "We will send confirmtion links soon.";
                SendEmail(entry.Email, "ITGigs registration request", $"Please click on the link to confirm your emil: {callbackUrl}");
            }
            catch (Exception ex)
            {
                //TODO: log the error
                return RedirectToAction("Index", "ITGigs"); // Error page
            }

            return View("Welcome");
        }

        private void SendEmail(string email, string subject, string message)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("your-mail@gmail.com", "your-mail-pass");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("whoever@me.com");
                mailMessage.To.Add(email);
                mailMessage.Body = message;
                mailMessage.Subject = subject;
                client.EnableSsl = true;
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                //do something here
            }
        }


    }
}