using E_Learning.DAL.Models;
using System.Net;
using System.Net.Mail;


namespace E_Learning.PL.Helpers
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
           var client= new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("horiahaji.77sr@gmail.com", "kvyn njil labh xrqk");
            client.Send("horiahaji.77sr@gmail.com", email.Receivers, email.Subject, email.Body);

        }
    }
}
