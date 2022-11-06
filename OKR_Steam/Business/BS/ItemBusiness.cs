using OKR_Steam.Business.IBS;
using OKR_Steam.DataAccess.DA;
using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Business.BS
{
    public class ItemBusiness : IItemBusiness
    {
        private readonly IItemDataAccess _itemDataAccess;
        private readonly AppDbContext _context;
        public ItemBusiness(IItemDataAccess itemDataAccess, AppDbContext context)
        {
            _itemDataAccess = itemDataAccess;
            _context = context;
        }

        public SteamItemModel GetItemDetailByItemId(Guid itemId)
        {
            var returnData = new SteamItemModel();

            var dbResponse = _itemDataAccess.GetItemDetailByItemId(itemId);

            returnData.Id = dbResponse.Id;
            returnData.ItemId = dbResponse.ItemId;
            returnData.ItemName = dbResponse.ItemName;
            returnData.ItemCondition = Enum.GetName(typeof(Enums.Enums.ItemExteriors), dbResponse.ItemCondition);
            returnData.ItemFloat = dbResponse.ItemFloat;
            returnData.HasSticker = dbResponse.HasSticker;
            returnData.StickerId = dbResponse.StickerId;

            return returnData;
        }
    }
}
