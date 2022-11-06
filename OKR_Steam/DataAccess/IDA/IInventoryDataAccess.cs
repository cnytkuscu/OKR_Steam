using OKR_Steam.Models.DBModels.DBResponseModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.DataAccess.IDA
{
    public interface IInventoryDataAccess
    {
        public List<SteamInventoryDBResponseModel> GetSteamInventoryByUserId(Guid userId);
    }
}
