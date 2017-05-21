namespace OnlineStorePlatform.Web.Controllers.Base
{
    using OnlineStorePlatform.Data.Interfaces;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        private IOnlineStoreData data;
        protected BaseController(IOnlineStoreData data)
        {
            this.data = data;
        }
    }
}
