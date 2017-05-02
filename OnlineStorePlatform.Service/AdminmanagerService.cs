﻿namespace OnlineStorePlatform.Service
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

    public class AdminmanagerService : Service, IAdminmanagerService
    {
        public IEnumerable<SelectListItem> GetAllRoles()
        {
            var roles =  this.Context.Roles.ToList().Select(r=> new SelectListItem()
            {
                Value = r.Name,
                Text = r.Name
            });
            return roles;
        }

        public void AssignRole(RoleVm rvm, string searchUser)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.Context));
            ApplicationUser user = userManager.Users.Where(u=>u.Email.StartsWith(searchUser)).FirstOrDefault();
            var customerRole = this.Context.Roles.FirstOrDefault(r => r.Name == "customer");
            rvm.User = user.Id;
            var roles = user.Roles.ToArray();
            foreach (var role in user.Roles)
            {
                if (role.RoleId != customerRole.Id)
                {
                    user.Roles.Remove(role);
                }
                if (user.Roles.Count <=1)
                {
                    break;
                }
            }
            this.Context.SaveChanges();
            var ruser = userManager.Users.Where(u => u.Email.StartsWith(searchUser)).FirstOrDefault();
            user = userManager.FindById(rvm.User);
           
            userManager.AddToRole(rvm.User, rvm.Role);
        }

        public void SendDeliver(int? id)
        {
            Order order = this.Context.Orders.Find(id);
            order.IsDelivered = true;
            this.Context.SaveChanges();
        }

        public IEnumerable<OrderVm> GetAllOrders(int? page)
        {
            IEnumerable<Order> orders = this.Context.Orders;
            IEnumerable<OrderVm> vms = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderVm>>(orders);
            return vms.ToPagedList(page ?? 1, 8);
        }

        public List<string> GetUserEmailAsString(string term)
        {
            return this.Context.Users.Where(user => user.Email.StartsWith(term)).Select(u => u.Email).ToList();
        }
    }
}
