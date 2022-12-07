using Resources.DBModels.ResponseModels;

namespace Interfaces.IDA
{
    public interface IInventoryDataAccess
    {
        public List<SteamInventoryDBResponseModel> GetSteamInventoryByUserId(Guid userId);
    }
}
