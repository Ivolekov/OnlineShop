namespace OnlineStorePlatform.Service
{
    using System.Collections.Generic;
    using Models.ViewModels.Category;
    using Models.EntityModels;
    using AutoMapper;
    using Models.ViewModels.Products;
    using Interfaces;
    using System.Net.Mail;
    using System.Net;
    using System.Text;
    using Data.Interfaces;
    using System;

    public class HomeService : Service, IHomeService
    {
        private EmailSettings emailSettings;

        public HomeService(IOnlineStoreData context) 
            : base(context)
        {
            this.emailSettings = new EmailSettings();
        }

        public IEnumerable<CategoriesVm> GetAllCategories()
        {
            IEnumerable<Category> model = this.Context.Categories.GetAll();
            IEnumerable<CategoriesVm> vms = Mapper.Instance.Map<IEnumerable<Category>, IEnumerable<CategoriesVm>>(model);
            return vms;
        }

        public IEnumerable<GetAllProductsVm> GetProductList()
        {
            IEnumerable<Product> model = this.Context.Products.GetAll();
            IEnumerable<GetAllProductsVm> vms = Mapper.Map<IEnumerable<Product>, IEnumerable<GetAllProductsVm>>(model);
            return vms;
        }

        public void SendEmailFromContactForm(ContactFormDetails contactDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username,
                        emailSettings.Password);


                StringBuilder body = new StringBuilder()
                    .AppendLine("A new mesage from customer: " + contactDetails.FirsName)
                    .AppendLine("---")
                    .AppendLine("Email: " + contactDetails.Email)
                    .AppendLine("---")
                    .AppendLine("Phone: " + contactDetails.PhoneNumber)
                    .AppendLine("---")
                    .AppendLine("Subject: " + contactDetails.Subject)
                    .AppendLine("---")
                    .AppendLine("Message: " + contactDetails.Message);
                MailMessage mailMessage = new MailMessage(new MailAddress(emailSettings.MailFromAddress).Address,
                    new MailAddress(emailSettings.MailToAddress).Address,
                    "New Message From Contact Form",
                    body.ToString());

                smtpClient.Send(mailMessage);
            }
        }

        public IEnumerable<GetAllProductsVm> TakeFourProducts()
        {
            IEnumerable<Product> products = this.Context.Products.Take(4);
            IEnumerable<GetAllProductsVm> vms = Mapper.Map<IEnumerable<Product>, IEnumerable<GetAllProductsVm>>(products);
            return vms;
        }
    }
}
