namespace OnlineStorePlatform.Data.Mocks
{
    using OnlineStorePlatform.Models.EntityModels;
    using System.Linq;
    public class FakeCategoryDbSet : FakeDbSet<Category>
    {
        public override Category Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(cat => cat.Id == wantedId);
        }
    }
}
