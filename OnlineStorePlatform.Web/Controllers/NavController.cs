namespace OnlineStorePlatform.Web.Controllers
{
    using Base;
    using Data;
    using Data.Interfaces;
    using Service;
    using Service.Interfaces;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class NavController : BaseController
    {
        private INavService service;

        public NavController(INavService service) 
            : base(new OnlineStoreData(new OnlineStorePlatformContext()))
        {
            this.service = service;
        }
        public NavController(IOnlineStoreData data, INavService service) : base(data)
        {
            this.service = new NavService(data);
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = this.service.GetAllCategories();
            return this.PartialView(categories);
        }
    }
}
