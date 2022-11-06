using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Business.IBS
{
    public interface IItemBusiness
    {
        public SteamItemModel GetItemDetailByItemId(Guid itemId);
    }
}
