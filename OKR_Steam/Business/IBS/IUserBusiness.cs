using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Models.DBModels;
using OKR_Steam.Models.DBModels.DBRequestModels;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Business.IBS
{
    public interface IUserBusiness
    {
        public SteamProfileModel GetSteamProfileDataFromURL(string profileURL);
        public SteamProfileModel GetSteamProfileDataByName(string username);
        public SteamProfileModel GetSteamUserStatusByUsername(string username);

        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SteamProfileRequestModel steamProfileModel);

        public ProcessResult<SteamProfileDatabaseModel> UpdateSteamProfileDataByUsername(UpdateSteamProfileData steamProfileModel);
    }
}
