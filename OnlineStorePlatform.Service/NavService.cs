namespace OnlineStorePlatform.Service
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Interfaces;

    public class NavService : Service, INavService
    {
        public const int PageSize = 6;

        public NavService(IOnlineStoreData context) 
            : base(context)
        {
        }

        public IEnumerable<string> GetAllCategories()
        {
            IEnumerable<string> categoriesAsString = this.Context.Products.GetAll().Select(x => x.Category.Name).Distinct().OrderBy(x => x);
            HashSet<string> categoriesForReturn = new HashSet<string>();
            foreach (var categoryName in categoriesAsString)
            {
                if (categoryName != null)
                {
                    categoriesForReturn.Add(categoryName);
                }
            }
            return categoriesForReturn;
        }
    }
}
