using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Models.DBModels.DBRequestModels;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Controllers.IC
{
    public interface IUserController
    {
        #region GET METHODS
        public IActionResult GetSteamProfileDataFromURL(string profileURL);
        public IActionResult GetSteamProfileDataByName(string username);
        public IActionResult GetSteamUserStatusByUsername(string username);
        #endregion


        #region POST METHODS
        public IActionResult SaveSteamProfileData(SteamProfileRequestModel steamProfileModel);
        #endregion

        #region PUT METHODS
        public IActionResult UpdateSteamProfileDataByUsername(UpdateSteamProfileData steamProfileModel);
        #endregion


        #region DELETE METHODS
        #endregion

    }
}
