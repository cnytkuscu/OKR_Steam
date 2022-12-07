using Resources.ResponseModels;

namespace Interfaces.IBS
{
    public interface IInventoryBusiness
    {
        public ProcessResult<SteamInventoryModel> GetSteamInventoryByUsername(string username);
    }
}
