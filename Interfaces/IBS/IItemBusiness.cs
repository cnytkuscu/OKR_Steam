using Resources.ResponseModels;

namespace Interfaces.IBS
{
    public interface IItemBusiness
    {
        public ProcessResult<SteamItemModel> GetItemDetailByItemId(Guid itemId);
    }
}
