using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Models.DBModels;
using OKR_Steam.Models.DBModels.DBRequestModels;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Business.IBS
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
