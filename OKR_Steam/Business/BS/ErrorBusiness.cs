using OKR_Steam.Business.IBS;
using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.DBModels.Tables;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Business.BS
{
    public class ErrorBusiness : IErrorBusiness
    {
        private readonly IErrorDataAccess _errorDataAccess;
        
        public ErrorBusiness(IErrorDataAccess errorDataAccess)
        {
            _errorDataAccess = errorDataAccess;
        }

        public void Insert(ErrorModel error)
        {
            _errorDataAccess.Insert(error);
        }
    }
}
