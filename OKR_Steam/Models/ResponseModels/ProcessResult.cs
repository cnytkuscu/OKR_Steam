namespace OKR_Steam.Models.ResponseModels
{
    public class ProcessResult<T>
    {
        public T ReturnData { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }
}