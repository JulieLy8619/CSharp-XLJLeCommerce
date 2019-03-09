using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;

        }
      /// <summary>
      /// bring in the email(user's emailaddress, and subject of the email we will send to user, and message
      /// </summary>
      /// <param name="email">user's email</param>
      /// <param name="subject">subject line of email</param>
      /// <param name="htmlMessage">message of email</param>
      /// <returns>when email has been sent</returns>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(_configuration["Sendgrid_Api_Key"]);
            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom("noreply@mystical_creatures.com","Mystical Creatures");
            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html,htmlMessage);
            await client.SendEmailAsync(msg);
        }
    }
}
