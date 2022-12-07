using Resources.DBModels.RequestModels;
using Resources.DBModels.ResponseModels;
using Resources.DBModels.Tables;

namespace Interfaces.IDA
{
    public interface IUserDataAccess
    {
        public SteamProfileDBResponse GetSteamProfileDataFromURL(string profileURL);
        public SteamProfileDBResponse GetSteamProfileDataByName(string username);
        public SteamProfileDBResponse GetSteamUserStatusByUsername(string username);

        public SteamProfileDatabaseModel SaveSteamProfileData(SaveSteamProfileData steamProfileModel);


        public SteamProfileDatabaseModel UpdateSteamProfileDataByUsername(UpdateSteamProfileData steamProfileData);
    }
}
