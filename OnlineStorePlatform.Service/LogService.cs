namespace OnlineStorePlatform.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.ViewModels.Log;
    using Models.EntityModels;

    public class LogService : Service
    {
        public AllLogsPageVm GetAllLogsPageVm(string email, int? page)
        {
            var currentPage = 1;
            if (page != null)
            {
                currentPage = page.Value;
            }

            IEnumerable<Log> logs;
            if (email != null)
            {
                logs = this.Context.Logs.Where(log => log.User.Email == email);
            }
            else
            {
                logs = this.Context.Logs;
            }

            int allLogPagesCount = logs.Count() / 20 + (logs.Count() % 20 == 0 ? 0 : 1);
            int logsTotake = 20;
            if (allLogPagesCount == currentPage)
            {
                logsTotake = logs.Count() % 20 == 0 ? 20 : logs.Count() % 20;
            }

            logs = logs.Skip((currentPage - 1) * 20).Take(logsTotake);

            List<AllLogVm> logVms = new List<AllLogVm>();
            foreach (Log log in logs)
            {
                logVms.Add(new AllLogVm()
                {
                    Operation = log.Operation,
                    ModfiedTable = log.ModifiedTableName,
                    Email = log.User.Email,
                    ModifiedAt = log.ModifiedAt
                });
            }


            AllLogsPageVm pageVm = new AllLogsPageVm()
            {
                WantedEmail = email,
                CurrentPage = currentPage,
                TotalNumberOfPages = allLogPagesCount,
                Logs = logVms
            };

            return pageVm;
        }
    }
}
