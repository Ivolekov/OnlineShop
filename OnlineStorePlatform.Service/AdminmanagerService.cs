namespace OnlineStorePlatform.Service
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using Models.ViewModels.Account;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Models.ViewModels.Order;
    using AutoMapper;

    public class AdminmanagerService : Service
    {
        public IEnumerable<SelectListItem> GetAllUsers()
        {
            
            var user = this.Context.Users.ToList().Select(u => new SelectListItem()
            {
                Value = u.Id,
                Text = u.Email
            });
            return user;
        }

        public IEnumerable<SelectListItem> GetAllRoles()
        {
            var roles =  this.Context.Roles.ToList().Select(r=> new SelectListItem()
            {
                Value = r.Name,
                Text = r.Name
            });
            return roles;
        }

        public void AssignRole(RoleVm rvm)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.Context));//this.Context
            var user = userManager.FindById(rvm.User);
            userManager.AddToRole(rvm.User, rvm.Role);
        }

        public IEnumerable<OrderVm> GetAllOrders()
        {
            IEnumerable<Order> orders = this.Context.Orders;
            IEnumerable<OrderVm> vms = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderVm>>(orders);
            return vms;
        }
    }
}
