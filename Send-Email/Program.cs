using System;
using System.Net;
using System.Net.Mail;

namespace Send_Email
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Console.WriteLine("Sending mail...");


            try
            {
                MailMessage mailMessage = new MailMessage("YOUR_EMAIL_ADDRESS", "RECIPIENT_EMAIL_ADDRESS");
                mailMessage.Subject = "This is a test email.";
                mailMessage.Body = "This is my test email body.";
                SendMail(mailMessage);

            }
            catch (Exception)
            {
                Console.WriteLine("Exception caught!");
                Console.WriteLine("1. Edit the addresses and passwords, both in Main and in the SendMail method.");
                Console.WriteLine("2. Unblock the \"Less secure app access\" in your gmail account settings.");
            }


            Console.ReadLine();
        }



        public static void SendMail(MailMessage message)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.googlemail.com";
            client.Port = 587; 
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("YOUR_EMAIL_ADDRESS", "YOUR_PASSWORD");
            client.Send(message);
        }


    }
}
