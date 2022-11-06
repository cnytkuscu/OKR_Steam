using Microsoft.EntityFrameworkCore;
using OKR_Steam.Business.IBS;
using OKR_Steam.DataAccess.DA;
using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.DBModels.DBResponseModels;
using OKR_Steam.Models.ResponseModels;

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

        public SteamInventoryModel GetSteamInventoryByUsername(string username)
        {
            var returnData = new SteamInventoryModel();
            var itemList = new List<ItemDetail>();
            var dbResponse = new List<SteamInventoryDBResponseModel>();

            if (String.IsNullOrEmpty(username)) return returnData;

            //Check if User Exists
            var userData = new UserBusiness(new UserDataAccess(_context), _context).GetSteamProfileDataByName(username);
            if (userData.response.players.Count > 0)
            {
                returnData.Username = userData.response.players[0].personaname;
                returnData.SteamId = userData.response.players[0].steamid;

                dbResponse = _inventoryDataAccess.GetSteamInventoryByUserId(Guid.Parse(userData.response.players[0].Id)); // Inventory done.

                if(dbResponse.Count> 0)
                {
                    foreach (var item in dbResponse)
                    {
                        var itemData = new ItemBusiness(new ItemDataAccess(_context), _context).GetItemDetailByItemId(item.ItemId);
                        if(itemData != null)
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

            returnData.ItemDetail = itemList;



            return returnData;
        }
    }
}
