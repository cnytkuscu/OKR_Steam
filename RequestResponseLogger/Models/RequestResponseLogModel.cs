using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseLogger.Models
{
    public class RequestResponseLogModel
    {
        public string LogId { get; set; }
        public DateTime? RequestDateTime { get; set; }
        public string RequestPath { get; set; }
        public string RequestMethod { get; set; }
        public string RequestBody { get; set; }
        public string RequestContentType { get; set; }


        public DateTime? ResponseDateTime { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseBody { get; set; }
        public string ResponseContentType { get; set; }


        public bool? IsExceptionActionLevel { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }

        public RequestResponseLogModel()
        {
            LogId = Guid.NewGuid().ToString();
        }
    }
}
