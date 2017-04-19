namespace OnlineStorePlatform.Models.EntityModels
{
    using Enums;
    using System;
    public class Log
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public OperationLog Operation { get; set; }

        public string ModifiedTableName { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
