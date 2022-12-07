using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.DBModels.ResponseModels
{
    public class SteamInventoryDBResponseModel
    {
        public Guid Id { get; set; }
        public Guid SteamId { get; set; }
        public Guid ItemId { get; set; }
        public int Status { get; set; }

    }
}
