namespace OnlineStorePlatform.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public bool IsDelivered { get; set; }

        public string DateTime { get; set; }
    }
}
