using OnlineStorePlatform.Data;
using OnlineStorePlatform.Data.Interfaces;
using OnlineStorePlatform.Models.ViewModels.Log;
using OnlineStorePlatform.Service;
using OnlineStorePlatform.Service.Interfaces;
using OnlineStorePlatform.Web.Controllers.Base;
using System.Web.Mvc;

namespace OnlineStorePlatform.Web.Controllers
{
    //TODO: Authorize, pagenation not working, logs for products, extent functionality
    
    [Authorize(Roles ="manager")]
    [HandleError]
    public class LogController : BaseController
    {
        private ILogService service;

        public LogController(ILogService service) 
            : base(new OnlineStoreData(new OnlineStorePlatformContext()))
        {
            this.service = service;
        }
        public LogController(IOnlineStoreData data, ILogService service) : base(data)
        {
            this.service = new LogService(data);
        }

        [HttpGet]
        public ActionResult All(string email, int? page)
        {

            AllLogsPageVm vm = this.service.GetAllLogsPageVm(email, page);
            return this.View(vm);
        }
    }
}