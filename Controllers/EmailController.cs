using System.Globalization;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace SimpleEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("luther53@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("luther53@ethereal.email"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smpt = new SmtpClient();
            smpt.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smpt.Authenticate("luther53@ethereal.email", "26evysmwTXGAbpfWwe");
            smpt.Send(email);
            smpt.Disconnect(true);

            return Ok();
        }
    }
}
