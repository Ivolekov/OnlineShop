namespace OnlineStorePlatform.Models.ViewModels.Log
{
    using System.Collections.Generic;
    public class AllLogsPageVm
    {
        public int CurrentPage { get; set; }

        public int TotalNumberOfPages { get; set; }

        public IEnumerable<AllLogVm> Logs { get; set; }

        public string WantedEmail { get; set; }
    }
}
