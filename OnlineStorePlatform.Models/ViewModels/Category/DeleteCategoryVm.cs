namespace OnlineStorePlatform.Models.ViewModels.Category
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DeleteCategoryVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string ImageUrl
        {
            get
            {
                return this.Name + this.Id + ".png";
            }
        }
    }
}
