using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Business.IBS
{
    public interface IInventoryBusiness
    {
        public ProcessResult<SteamInventoryModel> GetSteamInventoryByUsername(string username);
    }
}
