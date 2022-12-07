using Interfaces.IDA;
using Resources.AppDbContex;
using Resources.DBModels.Tables;

namespace RequestResponseLogger.DataAccess
{
    public class ServiceLogDataAccess : IServiceLogDataAccess
    {
        private readonly AppDbContext context;
        public ServiceLogDataAccess(AppDbContext _context)
        {
            context = _context;
        }
        public void Insert(ServiceLogDatabaseModel dbModel)
        {
            context.ServiceLog.Add(dbModel);
            context.SaveChanges();
        }
    }
}
