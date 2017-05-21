namespace OnlineStorePlatform.Service.Interfaces
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using OnlineStorePlatform.Models.ViewModels.Account;
    using OnlineStorePlatform.Models.ViewModels.Order;
    public interface IAdminmanagerService
    {
        void AssignRole(RoleVm rvm, string searchUser);
        IEnumerable<OrderVm> GetAllOrders(int? page);
        IEnumerable<SelectListItem> GetAllRoles();
        List<string> GetUserEmailAsString(string term);
        void SendDeliver(int id);
    }
}