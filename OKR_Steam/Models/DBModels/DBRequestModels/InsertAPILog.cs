namespace OKR_Steam.Models.DBModels.DBRequestModels
{
    public class InsertAPILog
    {
        public string LogId { get; set; }
        public string MethodName { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime dateTime { get; set; }
        public int TotalTime { get; set; }
    }
}
