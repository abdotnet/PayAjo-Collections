using Microsoft.Extensions.Configuration;
using PayAjo.Domain.Infrastucture.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture.Notification
{
    public class EmailNotification : IEmailNotify
    {
        private  string  _username;
        private string _password;
        private readonly string _sendername;
        private string _coperateEmail;
        private readonly IConfiguration _config;

        public EmailNotification(IConfiguration config)
        {
            _config = config;

            _username = _config["Cred:Username"];
            _password = _config["Cred:Password"];
            _sendername = _config["Cred:SenderName"];
            _coperateEmail = _config["Cred:CoperateEmail"];
        }
        #region Email Smtp
        private Operation Send(MailMessage mail)
        {
            return Operation.Create(() =>
            {
                // Create the email object first, then add the properties.
                SmtpClient client = new SmtpClient();
                client.Port = 2525;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                // Re .. 
                //_username = ConfigurationManager.AppSettings["SMTP.UserName"];
                //_password = ConfigurationManager.AppSettings["SMTP.Password"];

                //Set Credentials
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_username, _password);

                // client.Host = "smtp.office365.com";
                client.Host = "smtp.elasticemail.com";
                //client.Host = "smtp.live.com";
                client.Send(mail);
            });
        }

        /// <summary>
        /// Take single email and send message to it , FilePath : specify the path of the d file  ..
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="ccEmail"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Operation SendEmail(string email, string subject, string message, string ccEmail = null, string filePath = null)
        {
            return Operation.Create(() =>
            {
                bool flag = false;
                const string emailFormat = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
                var mail = new MailMessage();

                if (!string.IsNullOrEmpty(email))
                    flag = Regex.IsMatch(email, emailFormat);

                if (!string.IsNullOrEmpty(email) && flag)
                {

                    mail.To.Add(new MailAddress(email));

                    if (!string.IsNullOrEmpty(ccEmail) && Regex.IsMatch(ccEmail, emailFormat))
                    {
                        mail.Bcc.Add(new MailAddress(ccEmail));
                    }

                    if (!string.IsNullOrEmpty(_coperateEmail))
                        mail.Bcc.Add(new MailAddress(_coperateEmail));

                    if (!string.IsNullOrEmpty(filePath))
                        mail.Attachments.Add(new Attachment(filePath));

                    mail.From = new MailAddress("noreply@payajo.com");
                    mail.IsBodyHtml = true;
                    mail.Subject = subject;
                    mail.Body = message;
                    Send(mail);
                }
            });
        }

        /// <summary>
        /// Take Array of emails and send a single message to it , FilePath : specify the path of the file  ..
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="ccEmail"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Operation SendEmail(string[] email, string subject, string message, string ccEmail = null, string filePath = null)
        {
            return Operation.Create(() =>
            {
                bool flag = false;
                string emailFormat = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
                var mail = new MailMessage();

                foreach (var item in email)
                {
                    if (!string.IsNullOrEmpty(item))
                        flag = Regex.IsMatch(item, emailFormat);

                    if (!string.IsNullOrEmpty(item) && flag)
                    {
                        mail.To.Add(new MailAddress(item));
                    }
                }

                if (!string.IsNullOrEmpty(ccEmail) && Regex.IsMatch(ccEmail, emailFormat))
                {
                    mail.Bcc.Add(new MailAddress(ccEmail));
                }

                if (!string.IsNullOrEmpty(_coperateEmail))
                    mail.Bcc.Add(new MailAddress(_coperateEmail));

                if (filePath != null)
                    mail.Attachments.Add(new Attachment(filePath));

                mail.From = new MailAddress("noreply@penremit.ng");
                mail.IsBodyHtml = true;
                mail.Subject = subject;
                mail.Body = message;
                Send(mail);

            });
        }

        #endregion

        private void DisableSSLTrust()
        {
            try
            {
                //Change SSL checks so that all checks pass
                ServicePointManager.ServerCertificateValidationCallback = (s, cert, chain, errors) => true;
            }
            catch { }
        }
    }
}
