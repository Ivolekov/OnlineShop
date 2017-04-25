﻿namespace OnlineStorePlatform.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [NotMapped]
        public string Image
        {
            get
            {
                return this.Name + this.Id + ".png";
            }
            set { Image = value; }
        }
    }
}
