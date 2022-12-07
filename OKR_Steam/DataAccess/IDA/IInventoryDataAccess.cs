namespace OKR_Steam.DataAccess.IDA
{
    public interface IInventoryDataAccess
    {
        public List<SteamInventoryDBResponseModel> GetSteamInventoryByUserId(Guid userId);
    }
}
