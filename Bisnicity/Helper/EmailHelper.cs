/*************************************************************************************************************/
/*Class Name    : EmailHelper.cs                                                                       /
/*Created By    : Hamza Nayef                                                                             */
/*Ceation Date  : 22-10-2021                                                                            */
/******************************************************************************************************/
using System;
using System.Net.Mail;

namespace Bisnicity.Helper
{
    public static class EmailHelper
    {
        #region Methods 
        #region Method :: SendEmail
        public static bool SendEmail(string userEmail, string confirmationLink)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("bisniscity@gmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Confirm your email";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = confirmationLink;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("samersafi9512@gmail.com", "Samersafi@1412");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }
        #endregion
        #endregion
    }
}
