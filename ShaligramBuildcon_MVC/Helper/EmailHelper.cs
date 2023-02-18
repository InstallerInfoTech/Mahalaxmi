using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace ShaligramBuildcon_MVC.Helper
{
    public class EmailHelper
    {
        #region Send Mail Method
        public static bool SendMail(string to, string subject, string bodyTemplate, bool isHtml = false, string bcc = "", string ccMail = "", string attachmentFileName = "")
        {
            var fromEmail = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"];
            var email = System.Configuration.ConfigurationManager.AppSettings["EmailUserName"];
            var password = System.Configuration.ConfigurationManager.AppSettings["EmailPasssword"];
            int PortNumber = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PortNumber"]);
            string HostName = System.Configuration.ConfigurationManager.AppSettings["HostName"];

            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(fromEmail);
            mail.Subject = subject;
            mail.Body = bodyTemplate;
            mail.IsBodyHtml = true;

            if (ccMail != "" && ccMail != null)
            {
                mail.CC.Add(ccMail);
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = HostName;
            smtp.Port = PortNumber;

            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential(email, password);// Enter seders User name and password
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public static string SendMailWithAttachment(string[] toCollection, string subject, string bodyTemplate, bool isHtml = false, string bcc = "", string ccMail = "", IEnumerable<HttpPostedFileBase> files = null)
        {
            var fromEmail = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"];
            var email = System.Configuration.ConfigurationManager.AppSettings["EmailUserName"];
            var password = System.Configuration.ConfigurationManager.AppSettings["EmailPasssword"];
            int PortNumber = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PortNumber"]);
            string HostName = System.Configuration.ConfigurationManager.AppSettings["HostName"];

            MailMessage mail = new MailMessage();
            foreach(var to in toCollection)
            {
                mail.To.Add(to.TrimEnd().TrimStart());
            }

            mail.From = new MailAddress(fromEmail);
            mail.Subject = subject;
            mail.Body = bodyTemplate;
            mail.IsBodyHtml = true;

            if (ccMail != "" && ccMail != null)
            {
                mail.CC.Add(ccMail);
            }

            if(files != null)
            {
                if(files.Count() > 0)
                {
                    foreach(HttpPostedFileBase file in files)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        mail.Attachments.Add(new Attachment(file.InputStream, fileName));
                    }
                }
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = HostName;
            smtp.Port = PortNumber;

            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential(email, password); //Enter senders User name and password
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            
            try
            {
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return string.Empty;
        }

        public static void SendAsyncEmail(string to, string subject, string body, bool isHtml = false, string bcc = "",
            string cc = "", string attachmentFileName = "")
        {
            Task task = new Task(() => SendMail(to, subject, body, isHtml, bcc, cc, attachmentFileName));
            task.Start();
        }


        #endregion
    }
}