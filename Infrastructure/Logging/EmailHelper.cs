using System;
using System.Net.Mail;

namespace app_datumation.Infrastructure.Logging
{
    public interface IEmailHelper
    {
        void GenerateEmail(string subject, string body);
    }
    public class EmailHelper : IEmailHelper
    {
        private SmtpClient _smtpClient;
        public EmailHelper(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }
        public void GenerateEmail(string subject, string body)
        {
            var message = new MailMessage();
            message.Body = subject;
            message.From = new MailAddress("Datumation_noreply@app_datumation.com");
            message.To.Add("eljefenikita@gmail.com");
            message.CC.Add("eljefenikita@gmail.com");
            _smtpClient.Send(message);
        }
    }
}