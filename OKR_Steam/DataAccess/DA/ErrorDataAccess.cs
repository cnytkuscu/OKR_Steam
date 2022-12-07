using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.DBModels.Tables;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.DataAccess.DA
{
    public class ErrorDataAccess : IErrorDataAccess
    {
        private readonly AppDbContext context;
        public ErrorDataAccess(AppDbContext _context)
        {
            context = _context;
        }
        public void Insert(ErrorModel errorModel)
        {

            var dbData = new ErrorLogDatabaseModel()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                IsAuthenticated = errorModel.IsAuthenticated,
                ExceptionType = errorModel.ExceptionType,
                StackTrace = errorModel.StackTrace,
                Message = errorModel.Message,
                StatusCode = errorModel.StatusCode
            };

            context.ErrorLog.Add(dbData);
            context.SaveChanges();
        }
    }
}
