namespace OnlineStorePlatform.Models.ViewModels.Category
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    public class EditCategoryVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public byte[] Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public string ImageUrl
        {
            get
            {
                return this.Name + this.Id + ".png";
            }
        }
    }
}
