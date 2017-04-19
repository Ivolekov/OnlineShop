namespace OnlineStorePlatform.Models.ViewModels.Log
{
    using Enums;
    using System;

    public class AllLogVm
    {
        public string Email { get; set; }

        public OperationLog Operation { get; set; }

        public DateTime ModifiedAt { get; set; }

        public string ModfiedTable { get; set; }
    }
}
