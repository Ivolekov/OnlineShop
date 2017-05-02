namespace OnlineStorePlatform.Service
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class NavService : Service, INavService
    {
        public const int PageSize = 6;
        public IEnumerable<string> GetAllCategories()
        {
            return this.Context.Products.Select(x => x.Category.Name).Distinct().OrderBy(x => x);
        }
    }
}
