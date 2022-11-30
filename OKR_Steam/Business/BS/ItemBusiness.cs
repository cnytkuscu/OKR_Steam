using OKR_Steam.Business.IBS;
using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.DBModels.Tables;
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

        public ProcessResult<SteamItemModel> GetItemDetailByItemId(Guid itemId)
        {
            var returnData = new ProcessResult<SteamItemModel>();

            var dbResponse = _itemDataAccess.GetItemDetailByItemId(itemId);

            if (dbResponse != null && dbResponse.Id != Guid.Empty)
            {
                try
                {
                    returnData.ReturnData.Id = dbResponse.Id;
                    returnData.ReturnData.ItemId = dbResponse.ItemId;
                    returnData.ReturnData.ItemName = dbResponse.ItemName;
                    returnData.ReturnData.ItemCondition = Enum.GetName(typeof(Enums.Enums.ItemExteriors), dbResponse.ItemCondition);
                    returnData.ReturnData.ItemFloat = dbResponse.ItemFloat;
                    returnData.ReturnData.HasSticker = dbResponse.HasSticker;
                    returnData.ReturnData.StickerId = dbResponse.StickerId;
                }
                catch (Exception ex)
                {
                    returnData.HasError = true;
                    returnData.ErrorMessage = ex.Message + " --- " + ex.StackTrace;
                }
            }
            else
            {
                returnData.ErrorMessage = "There is no Item with that ItemId";
                returnData.HasError = false;
            }

            return returnData;
        }
    }
}
