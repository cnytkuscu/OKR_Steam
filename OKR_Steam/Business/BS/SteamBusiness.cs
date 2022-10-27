using OKR_Steam.Business.IBS;
using OKR_Steam.DataAccess.DA;
using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.DBModels;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Business.BS
{
    public class SteamBusiness : ISteamBusiness
    {
        private readonly ISteamDataAccess _steamDataAccess;
        private readonly AppDbContext _context;
        public SteamBusiness(ISteamDataAccess steamDataAccess, AppDbContext context)
        {
            _steamDataAccess = steamDataAccess;
            _context = context;

        }

        public SteamProfileModel GetSteamProfileDataFromURL(string profileURL)
        {
            var returnData = new SteamProfileModel();

            returnData = _steamDataAccess.GetSteamProfileDataFromURL(profileURL);
            return returnData;
            
        }

        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SteamProfileRequestModel steamProfileModel)
        {
            var returnData = new ProcessResult<SteamProfileDatabaseModel>();
            returnData = _steamDataAccess.SaveSteamProfileData(steamProfileModel);
            return returnData;
        }
    }
}
