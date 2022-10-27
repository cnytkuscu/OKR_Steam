using OKR_Steam.DataAccess.DA;
using OKR_Steam.Models.DBModels;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.DataAccess.IDA
{
    public interface ISteamDataAccess
    {
        public SteamProfileModel GetSteamProfileDataFromURL(string profileURL);

        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SteamProfileRequestModel steamProfileModel, AppDbContext context);
    }
}
