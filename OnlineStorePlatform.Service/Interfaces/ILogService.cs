namespace OnlineStorePlatform.Service.Interfaces
{
    using OnlineStorePlatform.Models.ViewModels.Log;
    public interface ILogService
    {
        AllLogsPageVm GetAllLogsPageVm(string email, int? page);
    }
}