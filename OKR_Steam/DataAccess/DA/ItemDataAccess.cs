namespace OKR_Steam.DataAccess.DA
{
    public class ItemDataAccess : IItemDataAccess
    {
        private readonly AppDbContext context;
        public ItemDataAccess(AppDbContext _context)
        {
            context = _context;
        }
        public SteamItemDBResponseModel GetItemDetailByItemId(Guid itemId)
        {
            var returnData = new SteamItemDBResponseModel();

            var dbResponse = context.Item.FirstOrDefault(x => x.Id == itemId);
            if (dbResponse != null)
            {
                returnData.Id = dbResponse.Id;
                returnData.ItemId = dbResponse.ItemId;
                returnData.ItemName = dbResponse.ItemName;
                returnData.ItemCondition = dbResponse.ItemCondition;
                returnData.ItemFloat = dbResponse.ItemFloat;
                returnData.HasSticker = dbResponse.HasSticker;
                returnData.StickerId = dbResponse.StickerId;
            }

            return returnData;


        }
    }
}
