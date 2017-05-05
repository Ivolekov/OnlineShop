using OnlineStorePlatform.Data;
using OnlineStorePlatform.Data.Interfaces;
using OnlineStorePlatform.Models.ViewModels.Account;
using OnlineStorePlatform.Models.ViewModels.Order;
using OnlineStorePlatform.Service;
using OnlineStorePlatform.Service.Interfaces;
using OnlineStorePlatform.Web.Controllers.Base;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineStorePlatform.Web.Controllers
{
    [Authorize(Roles = "manager")]
    [RoutePrefix("manager")]
    [HandleError]
    public class AdminmanagerController : BaseController
    {
        private IAdminmanagerService service;

        public AdminmanagerController(IAdminmanagerService service) 
            : base(new OnlineStoreData(new OnlineStorePlatformContext()))
        {
            this.service = service;
        }
        public AdminmanagerController(IOnlineStoreData data, IAdminmanagerService service) : base(data)
        {
            this.service = new AdminmanagerService(data);
        }

        [Route("assign")]
        [HttpGet]
        public ActionResult Index()
        {
            var roles = this.service.GetAllRoles();
            ViewBag.Role = roles;
            return this.View(new RoleVm());
        }

        [HttpPost]
        public ActionResult Assign(RoleVm rvm, string searchUser)
        {
            if (string.IsNullOrEmpty(searchUser))
            {
                return this.View("UserCantBeEmpty");
            }
            else
            {
                this.service.AssignRole(rvm, searchUser);
                TempData["Rolemessage"] = "Role has been change";
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

        [Route("sentorders")]
        public ActionResult SentOrders(int id)
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