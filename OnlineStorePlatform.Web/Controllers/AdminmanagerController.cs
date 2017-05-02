using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStorePlatform.Models.EntityModels;
using OnlineStorePlatform.Models.ViewModels.Account;
using OnlineStorePlatform.Models.ViewModels.Order;
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

        [Route("assign")]
        [HttpGet]
        public ActionResult Index()
        {
            //var users = this.service.GetAllUsers();

            var roles = this.service.GetAllRoles();

            //ViewBag.User = users;
            ViewBag.Role = roles;
            return this.View(new RoleVm());
        }

        [HttpPost]
        //[Route("assign")]
        public ActionResult Assign(RoleVm rvm, string searchUser)
        {
            if (string.IsNullOrEmpty(searchUser))
            {
                return this.View("UserCantBeEmpty");
               // this.service.AssignRole(rvm, searchUser = null);
            }
            else
            {
                this.service.AssignRole(rvm, searchUser);
            }
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        [Route("orders")]
        public ActionResult Orders(int? page)
        {
            IEnumerable<OrderVm> vms = this.service.GetAllOrders(page);
            return this.View(vms);
        }
        //[HttpPost]
        [Route("sentorders")]
        public ActionResult SentOrders(int? id)
        {
            this.service.SendDeliver(id);
            return this.RedirectToAction("Orders");
        }

        public JsonResult GetUserEmailJson(string term)
        {
            List<string> usersEmail = new List<string>();
            usersEmail = this.service.GetUserEmailAsString(term);
            return this.Json(usersEmail, JsonRequestBehavior.AllowGet);
        }
    }
}