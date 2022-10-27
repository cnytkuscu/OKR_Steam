using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Controllers.IC
{
    public interface ISteamController
    {
        public IActionResult GetSteamProfileDataFromURL(string profileURL);
        public IActionResult SaveSteamProfileData(SteamProfileRequestModel steamProfileModel);
        
    }
}
