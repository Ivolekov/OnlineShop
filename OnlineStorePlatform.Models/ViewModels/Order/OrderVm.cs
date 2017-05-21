namespace OnlineStorePlatform.Models.ViewModels.Order
{
    using EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class OrderVm
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public bool IsDelivered { get; set; }
        public string DateTime { get; set; }
    }
}
