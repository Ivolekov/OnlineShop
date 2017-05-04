﻿namespace OnlineStorePlatform.Web.Controllers
{
    using Base;
    using Data;
    using Data.Interfaces;
    using Models.EntityModels;
    using Models.ViewModels.Category;
    using Service;
    using Service.Interfaces;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private IHomeService service;
        public HomeController(IHomeService service) 
            : base(new OnlineStoreData(new OnlineStorePlatformContext()))
        {
            this.service = service;
        }
        public HomeController(IOnlineStoreData data, IHomeService service) : base(data)
        {
            this.service = new HomeService(data);
        }

        [HttpGet]
        [Route]
        public ActionResult Index()
        {
            IEnumerable<CategoriesVm> vms = this.service.GetAllCategories();
            return View(vms);
        }

        [Route("about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return this.View();
        }

        [Route("contact")]
        public ActionResult Contact(ContactFormDetails contactFormDetails)
        {
            if (this.ModelState.IsValid)
            {
                this.service.SendEmailFromContactForm(contactFormDetails);
                TempData["contactFormMessage"] = "Your Message has been send. We will contact with you very soon";
                return this.RedirectToAction("Index");
            }
            return View();
        }

        
    }
}