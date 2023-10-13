using BackEndApi.General;
using MimeKit;
using System.Data;
using System.Net;
using MailKit.Net.Smtp;


namespace BackEndApi.Brain
{
    public class BubbleMain
    {
        // SINGLETON
        private static BubbleMain instance;

        public static BubbleMain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BubbleMain();
                }
                return instance;
            }
        }

        public void Test()
        {
            DataTable testTable = new DataTable();

            testTable = MyConnection.Instance.GetDataFromDb();
        }
        public void CreationPdf()
        {

            //Brain.CreationPdf.Instance.CreatePage();
            Brain.CreationPdf.Instance.CreatePageFree();

        }

        public String CreationPicture(string inputText)
        {

            String pathImage = Brain.CreationPicture.Instance.CreateImageAsync(inputText).Result;
            return pathImage;
        }

        public void StartSendMail(string text,string mail)
        {

            //SmtpClient client = new SmtpClient();

            //client.Host = "smtp.gmail.com";
            //client.Port = 587;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.EnableSsl = true;
            //client.Credentials = new NetworkCredential("mail", "psw");

            //MailMessage mailMessage = new MailMessage("mail",to: "mail",subject:"test",body:"AAA");
            //mailMessage.IsBodyHtml = true;
            //client.Send(mailMessage);

            //var smtpClient = new SmtpClient("smtp.gmail.com")
            //{
            //    Port = 587,
            //    Credentials = new NetworkCredential("mail", "psw"),
            //    EnableSsl = true,
            //};

            //smtpClient.Send("mail", "recipient", "subject", "body");



            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", "mail"));
            email.To.Add(new MailboxAddress("Receiver Name", "mail"));

            email.Subject = "Testing out email sending";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<b>Hello all the way from the land of C#</b>"
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("mail", "psw");

                smtp.Send(email);
                smtp.Disconnect(true);
            }

        }


        public void StartGetSaintOfDay()
        {
            string a = "";
        }
            
    }
}
