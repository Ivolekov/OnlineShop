﻿namespace OnlineStorePlatform.Models.ViewModels.Products
{
    using Category;
    using EntityModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    public class EditProductVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string CategoryName { get; set; }

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
