using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.DBModels.DBResponseModels;
using OKR_Steam.Models.DBModels.Tables;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.DataAccess.DA
{
    public class InventoryDataAccess : IInventoryDataAccess
    {
        private readonly AppDbContext context;
        public InventoryDataAccess(AppDbContext _context)
        {
            context = _context;
        }
        public List<SteamInventoryDBResponseModel> GetSteamInventoryByUserId(Guid userId)
        {
            var returnData = new List<SteamInventoryDBResponseModel>();
              
             
                var dbData = context.Inventory.Where(x => x.SteamId == userId).ToList();
                if (dbData == null) return returnData;
                foreach (var item in dbData)
                {
                    returnData.Add(new SteamInventoryDBResponseModel() { ItemId = item.ItemId, SteamId = item.SteamId });
                }
            
            return returnData;

        }
    }
}
