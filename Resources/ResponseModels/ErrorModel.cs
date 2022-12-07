namespace Resources.ResponseModels
{
    public class ErrorModel
    { 
        public DateTime Date { get; set; }
        public bool IsAuthenticated { get; set; }
        public string ExceptionType { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
     
              
                
                
                 
               
}
