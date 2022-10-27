using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Controllers.IC
{
    public interface ISteamController
    {
        #region GET METHODS
        public IActionResult GetSteamProfileDataFromURL(string profileURL);
        public IActionResult GetSteamProfileDataByName(string username);
        #endregion



        #region POST METHODS
        public IActionResult SaveSteamProfileData(SteamProfileRequestModel steamProfileModel);
        #endregion

    }
}
