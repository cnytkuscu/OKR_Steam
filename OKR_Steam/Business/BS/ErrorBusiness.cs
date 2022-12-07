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
