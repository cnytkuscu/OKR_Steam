namespace OKR_Steam.DataAccess.IDA
{
    public interface IItemDataAccess
    {
        public SteamItemDBResponseModel GetItemDetailByItemId(Guid itemId);
    }
}
