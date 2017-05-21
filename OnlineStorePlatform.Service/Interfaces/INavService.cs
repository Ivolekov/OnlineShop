namespace OnlineStorePlatform.Service.Interfaces
{
    using System.Collections.Generic;
    public interface INavService
    {
        IEnumerable<string> GetAllCategories();
    }
}