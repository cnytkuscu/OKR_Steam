using OKR_Steam.Models.DBModels;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Business.IBS
{
    public interface ISteamBusiness
    {
        public SteamProfileModel GetSteamProfileDataFromURL(string profileURL);

        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SteamProfileRequestModel steamProfileModel);
    }
}
