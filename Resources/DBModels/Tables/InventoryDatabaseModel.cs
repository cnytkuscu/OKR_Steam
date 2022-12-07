using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.DBModels.Tables
{
    public class InventoryDatabaseModel
    {
        public Guid Id { get; set; }
        public Guid SteamId { get; set; }
        public Guid ItemId { get; set; }
        public int Status { get; set; }
    }
}
