using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using WebAPI.Models;

namespace WebAPI.CustomCode
{
    public static class CommonMethod
    {
    
        public static void SendEmail(string email,string body,string subject)
        {
            try
            {
                using (MailMessage mm = new MailMessage())
                {
                    mm.To.Add(new MailAddress(email));
                    mm.Subject = subject;
                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Send(mm);
                };
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
            }
        }
    }
}
