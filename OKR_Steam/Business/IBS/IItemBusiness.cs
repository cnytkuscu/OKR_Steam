namespace OKR_Steam.Business.IBS
{
    public interface IItemBusiness
    {
        public ProcessResult<SteamItemModel> GetItemDetailByItemId(Guid itemId);
    }
}
