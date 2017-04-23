namespace OnlineStorePlatform.Models.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    public class EditCategoryBm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public byte[] Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
