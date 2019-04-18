using Datumation.Infrastructure.Logging;
using log4net;
using Datumation.Infrastructure.Configuration;
using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;

namespace Datumation.Infrastructure.Logging
{
    public class Logger : ILogFactory
    {
        private static log4net.ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void WriteMessage(string msg)
        {
            log.Debug(msg);
        }

        public void WriteMessage(string msg, Exception ex)
        {
            log.Debug(msg, ex);
        }

        public void GenerateEmail(string subject, string body)
        {
            try
            {
                using (SmtpClient mailClient = new SmtpClient())
                {

                    MailAddress to = new MailAddress("", "");

                    MailAddress from = new MailAddress("", "");

                    MailMessage emailMessage = new MailMessage(from, to);

                    //if (ConfigurationFactory.Instance.Configuration().LogEmailCcAddresses != null)
                    //{
                    //    foreach (string ccItem in ConfigurationFactory.Instance.Configuration().LogEmailCcAddresses)
                    //    {
                    //        emailMessage.CC.Add(ccItem);
                    //    }
                    //}

                    //if (ConfigurationFactory.Instance.Configuration().MailClientCc.MailSettingsEnableCc)
                    //{
                    //    foreach (var ccItem in ConfigurationFactory.Instance.Configuration().MailClientCc.EmailSettings)
                    //    {
                    //        if (ccItem.IsEnabled)
                    //        {
                    //            emailMessage.CC.Add(ccItem.EmailAddress);
                    //        }
                    //    }
                    //}

                    emailMessage.Subject = subject;
                    emailMessage.Body = body;
                    mailClient.Send(emailMessage);
                }
            }
            catch (Exception ex)
            {
                StringBuilder errorMsg = new StringBuilder();
                // string currentMethod = Extensions.StringExtensions.GetCurrentMethod();

                // errorMsg.Append(currentMethod).Append(": ")
                //     .Append("Message").Append(": (").Append(ex.Message).Append(")")
                //     .Append("Inner Exception").Append(": [").Append(ex.InnerException).Append("]")
                //     .Append("Stack Trace").Append(": -->").Append("").Append(ex.StackTrace).Append("<--")
                //     .Append("End for ------>").Append(currentMethod);

                // log.Debug(errorMsg.ToString());
            }

        }
    }
}