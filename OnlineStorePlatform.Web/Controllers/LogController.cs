using OnlineStorePlatform.Models.ViewModels.Log;
using OnlineStorePlatform.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStorePlatform.Web.Controllers
{
    //TODO: Authorize, pagenation not working, logs for products, extent functionality
    public class LogController : Controller
    {
        private LogService service;

        public LogController()
        {
            this.service = new LogService();
        }

        [HttpGet]
        public ActionResult All(string email, int? page)
        {

            AllLogsPageVm vm = this.service.GetAllLogsPageVm(email, page);
            return this.View(vm);
        }
    }
}