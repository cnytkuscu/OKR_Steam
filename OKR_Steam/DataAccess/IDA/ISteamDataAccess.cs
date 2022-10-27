using OKR_Steam.DataAccess.DA;
using OKR_Steam.Models.DBModels;
using OKR_Steam.Models.DBModels.DBRequestModels;
using OKR_Steam.Models.DBModels.DBResponseModels;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.DataAccess.IDA
{
    public interface ISteamDataAccess
    {
        public SteamProfileDBResponse GetSteamProfileDataFromURL(string profileURL);
        public SteamProfileDBResponse GetSteamProfileDataByName(string username);

        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SaveSteamProfileData steamProfileModel);
    }
}
