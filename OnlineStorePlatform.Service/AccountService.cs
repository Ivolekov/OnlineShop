namespace OnlineStorePlatform.Service
{
    using Interfaces;
    using Models.EntityModels;
    using Data.Interfaces;
    using System;

    public class AccountService : Service, IAccountService
    {
        public AccountService(IOnlineStoreData context) 
            : base(context)
        {
        }

        public void CreateCustomer(User user)
        {
            Customer customer = new Customer();
            User currentUser = this.Context.Users.GetByStringId(user.Id);
            customer.User = currentUser;
            this.Context.Customers.InsertOrUpdate(customer);
            this.Context.SaveChanges();
        }
    }
}
