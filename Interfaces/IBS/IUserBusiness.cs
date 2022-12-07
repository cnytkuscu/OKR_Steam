using Resources.DBModels.RequestModels;
using Resources.DBModels.Tables;
using Resources.RequestModels;
using Resources.ResponseModels;

namespace Interfaces.IBS
{
    public interface IUserBusiness
    {
        public ProcessResult<SteamProfileModel> GetSteamProfileDataFromURL(string profileURL);
        public ProcessResult<SteamProfileModel> GetSteamProfileDataByName(string username);
        public ProcessResult<SteamProfileModel> GetSteamUserStatusByUsername(string username);

        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SteamProfileRequestModel steamProfileModel);

        public ProcessResult<SteamProfileDatabaseModel> UpdateSteamProfileDataByUsername(UpdateSteamProfileData steamProfileModel);
    }
}
