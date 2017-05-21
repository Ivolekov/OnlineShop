namespace OnlineStorePlatform.Data.Mocks
{
    using Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class FakeProductsDbSet : FakeDbSet<Product>
    {
        public override Product Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(p => p.Id == wantedId);
        }
    }
}
