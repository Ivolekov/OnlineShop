namespace OnlineStorePlatform.Service
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using Models.ViewModels.Account;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models.ViewModels.Order;
    using AutoMapper;
    using PagedList;
    using Interfaces;
    using Data.Interfaces;
    using Data;
    using System;

    public class AdminmanagerService : Service, IAdminmanagerService
    {
        public AdminmanagerService(IOnlineStoreData context) 
            : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllRoles()
        {
            using (OnlineStorePlatformContext db = new OnlineStorePlatformContext())
            {
                var roles = db.Roles.ToList().Select(r => new SelectListItem()
                {
                    Value = r.Name,
                    Text = r.Name
                });
                return roles;
            }
        }

        public void AssignRole(RoleVm rvm, string searchUser)
        {
            using (OnlineStorePlatformContext db = new OnlineStorePlatformContext())
            {
                var userManager = new UserManager<User>(new UserStore<User>(db));
                User user = userManager.Users.Where(u => u.Email.StartsWith(searchUser)).FirstOrDefault();
                var customerRole = db.Roles.FirstOrDefault(r => r.Name == "customer");
                rvm.User = user.Id;
                var roles = user.Roles.ToArray();
                foreach (var role in user.Roles)
                {
                    if (role.RoleId != customerRole.Id)
                    {
                        user.Roles.Remove(role);
                    }
                    if (user.Roles.Count <= 1)
                    {
                        break;
                    }
                }
                this.Context.SaveChanges();
                var ruser = userManager.Users.Where(u => u.Email.StartsWith(searchUser)).FirstOrDefault();
                user = userManager.FindById(rvm.User);

                userManager.AddToRole(rvm.User, rvm.Role);
            }
        }

        public void SendDeliver(int id)
        {
            Order order = this.Context.Orders.GetById(id);
            order.IsDelivered = true;
            this.Context.SaveChanges();
        }

        public IEnumerable<OrderVm> GetAllOrders(int? page)
        {
            IEnumerable<Order> orders = this.Context.Orders.GetAll();
            IEnumerable<OrderVm> vms = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderVm>>(orders);
            return vms.ToPagedList(page ?? 1, 8);
        }

        public List<string> GetUserEmailAsString(string term)
        {
            return this.Context.Users.Find(user => user.Email.StartsWith(term)).Select(u => u.Email).ToList();
        }
    }
}
