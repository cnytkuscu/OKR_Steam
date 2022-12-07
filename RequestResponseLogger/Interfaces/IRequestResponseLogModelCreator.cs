using RequestResponseLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseLogger.Interfaces
{
    public interface IRequestResponseLogModelCreator
    {
        RequestResponseLogModel LogModel { get; }
        string LogString();
    }
}
