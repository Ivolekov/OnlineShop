using OnlineStorePlatform.Models.ViewModels.Log;
using OnlineStorePlatform.Service.Interfaces;
using System.Web.Mvc;

namespace OnlineStorePlatform.Web.Controllers
{
    //TODO: Authorize, pagenation not working, logs for products, extent functionality
    public class LogController : Controller
    {
        private ILogService service;

        public LogController(ILogService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult All(string email, int? page)
        {

            AllLogsPageVm vm = this.service.GetAllLogsPageVm(email, page);
            return this.View(vm);
        }
    }
}