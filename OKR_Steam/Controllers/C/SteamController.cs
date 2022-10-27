using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Business.BS;
using OKR_Steam.Business.IBS;
using OKR_Steam.Controllers.IC;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Controllers.C
{
    [ApiController]
    [Route("[controller]")]
    public class SteamController : Controller, ISteamController
    {
        private readonly ISteamBusiness _steamBusiness;
        public SteamController(ISteamBusiness steamBusiness)
        {
            _steamBusiness = steamBusiness;
        }

        #region GET METHODS
       
        [HttpGet("GetSteamProfileDataFromURL/{profileURL}")]
        public IActionResult GetSteamProfileDataFromURL(string profileURL)
        {
            var returnData = _steamBusiness.GetSteamProfileDataFromURL(profileURL);

            return Ok(returnData);
        }
        #endregion


        #region POST METHODS
        [HttpPost("SaveSteamProfileData")]
        public IActionResult SaveSteamProfileData(SteamProfileRequestModel steamProfileModel)
        {
            var returnData = _steamBusiness.SaveSteamProfileData(steamProfileModel);
            return Ok(returnData);
        }
        #endregion



    }
}
