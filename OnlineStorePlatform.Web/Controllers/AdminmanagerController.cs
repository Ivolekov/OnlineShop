using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStorePlatform.Models.EntityModels;
using OnlineStorePlatform.Models.ViewModels.Account;
using OnlineStorePlatform.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStorePlatform.Web.Controllers
{
    [Authorize(Roles = "manager")]
    [RoutePrefix("manager")]
    public class AdminmanagerController : Controller
    {
        private AdminmanagerService service;
        public AdminmanagerController()
        {
            this.service = new AdminmanagerService();
        }

        [Route]
        [HttpGet]
        public ActionResult Index()
        {
            var users = this.service.GetAllUsers();

            var roles = this.service.GetAllRoles();

            ViewBag.User = users;
            ViewBag.Role = roles;
            return this.View(new RoleVm());
        }

        [HttpPost]
        public ActionResult Assign(RoleVm rvm)
        {
            this.service.AssignRole(rvm);
            return Redirect("Roles");
        }
    }
}