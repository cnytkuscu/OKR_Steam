using Resources.DBModels.ResponseModels;

namespace Interfaces.IDA
{
    public interface IItemDataAccess
    {
        public SteamItemDBResponseModel GetItemDetailByItemId(Guid itemId);
    }
}
