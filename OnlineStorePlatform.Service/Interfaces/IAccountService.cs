namespace OnlineStorePlatform.Service.Interfaces
{
    using OnlineStorePlatform.Models.EntityModels;
    public interface IAccountService
    {
        void CreateCustomer(User user);
    }
}