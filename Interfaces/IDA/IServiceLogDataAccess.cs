using Resources.DBModels.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.IDA
{
    public interface IServiceLogDataAccess{
        public void Insert(ServiceLogDatabaseModel dbModel);
    }
}
