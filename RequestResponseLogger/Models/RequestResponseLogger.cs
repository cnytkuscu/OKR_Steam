using Interfaces.IDA;
using Microsoft.Extensions.Logging;
using RequestResponseLogger.Interfaces;
using Resources.DBModels.Tables;

namespace RequestResponseLogger.Models
{
    public class RequestResponseLogger : IRequestResponseLogger
    {
        private readonly IServiceLogDataAccess _logger;

        public RequestResponseLogger(IServiceLogDataAccess logger)
        {
            _logger = logger;
        }
        public void Log(IRequestResponseLogModelCreator logCreator)
        {
            var dbData = new ServiceLogDatabaseModel()
            {
                Id = Guid.Parse(logCreator.LogModel.LogId),
                RequestDateTime = logCreator.LogModel.RequestDateTime,
                RequestPath = logCreator.LogModel.RequestPath,
                RequestMethod = logCreator.LogModel.RequestMethod,
                RequestBody = logCreator.LogModel.RequestBody,
                RequestContentType = logCreator.LogModel.RequestContentType,
                ResponseDateTime = logCreator.LogModel.ResponseDateTime,
                ResponseStatus = logCreator.LogModel.ResponseStatus,
                ResponseBody = logCreator.LogModel.ResponseBody,
                ResponseContentType = logCreator.LogModel.ResponseContentType,
                IsExceptionActionLevel = logCreator.LogModel.IsExceptionActionLevel,
                ExceptionMessage = logCreator.LogModel.ExceptionMessage,
                ExceptionStackTrace = logCreator.LogModel.ExceptionStackTrace
            };

            _logger.Insert(dbData);
        }
    }
}
