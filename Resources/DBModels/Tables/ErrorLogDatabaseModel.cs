using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.DBModels.Tables
{
    public class ErrorLogDatabaseModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsAuthenticated { get; set; }
        public string ExceptionType { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
