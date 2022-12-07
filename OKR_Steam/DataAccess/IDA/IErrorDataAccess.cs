using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.DataAccess.IDA
{
    public interface IErrorDataAccess
    {
        public void Insert(ErrorModel errorModel);
    }
}
