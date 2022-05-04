using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace _0_FramBase.Application.Email
{
  public class EmailServices:IEmailServices
    {

       
        public void SendEmail(string title, string messageBody, string destination)
        {
            var message = new MimeMessage();

            var from = new MailboxAddress("Atriya", "test@atriya.com");
            message.From.Add(from);

            var to = new MailboxAddress("User", destination);
            message.To.Add(to);

            message.Subject = title;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>{messageBody}</h1>",
            };

            message.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();
            client.Connect("192.168.1.1", 25, false);
            client.Authenticate("yasamanbagheri72@yahoo.com", "yasijoon72");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
