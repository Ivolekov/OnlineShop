namespace OnlineStorePlatform.Web.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class EmailSettings
    {
        //TODO: Take google app pass to send email
        public string MailToAddress = "ifreshbg@gmail.com";
        public string MailFromAddress = "ifreshbg@gmail.com";
        public bool UseSsl = true;
        public string Username = "ifreshbg@gmail.com";
        public string Password = "hgnmooedjjwfekpj"; // Create your own google app password, In the video I have shown you how to create app password.
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
}
