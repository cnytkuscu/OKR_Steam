using OKR_Steam.DataAccess.DA;

namespace OKR_Steam.Business.BS
{
    public class InventoryBusiness : IInventoryBusiness
    {
        private readonly IInventoryDataAccess _inventoryDataAccess;
        private readonly AppDbContext _context;
        public InventoryBusiness(IInventoryDataAccess inventoryDataAccess, AppDbContext context)
        {
            _inventoryDataAccess = inventoryDataAccess;
            _context = context;
        }

        public ProcessResult<SteamInventoryModel> GetSteamInventoryByUsername(string username)
        {
            var returnData = new ProcessResult<SteamInventoryModel>();
            var itemList = new List<ItemDetail>();
            var dbResponse = new List<SteamInventoryDBResponseModel>();

            if (String.IsNullOrEmpty(username)) return returnData;

            try
            {
                //Check if User Exists
                var userData = new UserBusiness(new UserDataAccess(_context)).GetSteamProfileDataByName(username).ReturnData;
                if (userData.response.players.Count > 0)
                {
                    returnData.ReturnData.Username = userData.response.players[0].personaname;
                    returnData.ReturnData.SteamId = userData.response.players[0].steamid;

                    dbResponse = _inventoryDataAccess.GetSteamInventoryByUserId(Guid.Parse(userData.response.players[0].Id)); // Inventory done.

                    if (dbResponse.Count > 0)
                    {
                        foreach (var item in dbResponse)
                        {
                            var itemData = new ItemBusiness(new ItemDataAccess(_context), _context).GetItemDetailByItemId(item.ItemId).ReturnData;
                            if (itemData != null)
                            {
                                itemList.Add(new ItemDetail()
                                {
                                    ItemName = itemData.ItemName,
                                    ItemCondition = itemData.ItemCondition,
                                    ItemFloat = itemData.ItemFloat,
                                    HasSticker = itemData.HasSticker
                                });
                            }
                        }
                    }
                }
                else
                {
                    returnData.HasError = false;
                    returnData.ErrorMessage = "There is User with that username.";
                }
            }
            catch (Exception ex)
            {
                returnData.HasError = true;
                returnData.ErrorMessage = ex.Message + " --- "+ ex.StackTrace;
            }

            returnData.ReturnData.ItemDetail = itemList;

            return returnData;
        }
    }
}
