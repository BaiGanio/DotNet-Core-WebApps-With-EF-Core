using ITGigs.LogService;
using ITGigs.LogService.Domain;
using ITGigs.NotificationService.Domain;
using ITGigs.UserService.Domain.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ITGigs.NotificationService
{
    public class NotificationManager : INotificationActor
    {
        private ILog _logger = Logger.GetInstance;
        private string confirmationEmailUrl = "http://localhost:55766/account/ValidateEmail";
        private string performerConfirmationUrl = "http://localhost:55766/account/performer";
        private string venueOwnerConfirmationUrl = "http://localhost:55766/account/venueOwner";
        //private string confirmationEmailUrl = "https://itgigs.azurewebsites.net/account/ValidateEmail";
        //private string performerConfirmationUrl = "https://itgigs.azurewebsites.net/account/performer";
        //private string venueOwnerConfirmationUrl = "https://itgigs.azurewebsites.net/account/venueOwner";


        public async Task SendChangePasswordEmailAsync(User user)
        {
            //TODO
        }

        public async Task SendConfirmationEmailAsync(User user)
        {
            string callbackUrl = $"{confirmationEmailUrl}?userId={user.Id}&validationCode={user.ValidationCode}";
            string link = $"<a href='{ callbackUrl}'>here</a>!";
            await SendEmailAsync(user.Email, "ITGigs registration request", $"Dear, {user.Username}. To confirm your account click  -> {link}");
        }
        public async Task SendPerformerRequestEmailAsync(User user)
        {
            string callbackUrl = $"{performerConfirmationUrl}?userId={user.Id}&validationCode={user.ValidationCode}";
            string link = $"<a href='{ callbackUrl}'>here</a>!";
            await SendEmailAsync(user.Email, "ITGigs performer request", $"Dear, {user.Username}. To confirm your request for performer in ITGigs click  -> {link}");
        }
        public async Task SendVenueOwnerRequestEmailAsync(User user)
        {
            string callbackUrl = $"{venueOwnerConfirmationUrl}?userId={user.Id}&validationCode={user.ValidationCode}";
            string link = $"<a href='{ callbackUrl}'>here</a>!";
            await SendEmailAsync(user.Email, "ITGigs venue owner request", $"To confirm your request for venue owner in ITGigs click  -> {link}");
        }

        private async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    //Credentials = new NetworkCredential("your-name@gmail.com", "your-pass")
                    Credentials = new NetworkCredential("exceptionhelper@gmail.com", "b@40neHk@")
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("whoever@me.com")
                };
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
    }
}
