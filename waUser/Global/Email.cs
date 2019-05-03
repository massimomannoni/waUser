using System;
using System.Net.Mail;
using System.IO;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using waUser.Constants;
using waUser.Models;

namespace waUser.Utility

{
    internal class Sender
    {
        private static readonly string EMAILTEMPLATE = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        internal static async Task EmailConfirmation(User user, string token)
        {
            var message = new MailMessage();
            message.From = new MailAddress("activate@mtp.it");
            message.To.Add(new MailAddress(user.Email));
            message.Subject = "Welcome to Shapps"; 
            message.Body = File.ReadAllText(EMAILTEMPLATE + "/MailProspect.html").Replace("$(ActivationLink)", string.Format("https://localhost:44386/Activate?tk={0}", HttpUtility.UrlEncode(token)));
            message.IsBodyHtml = true;

            await Send(message);
        }

        private static async Task Send(MailMessage message)
        {
            SmtpClient client = new SmtpClient();

            try
            {
                client.Host = Smtp.HOST;
                client.Port = Smtp.PORT;
                client.EnableSsl = Smtp.ENABLESSL;
                NetworkCredential credential = new NetworkCredential(Smtp.USER, Smtp.PASSWORD, "");

                client.Credentials = credential;

                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client = null;
            }
        }

    }
}