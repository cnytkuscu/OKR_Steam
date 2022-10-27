using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Business.BS;
using OKR_Steam.Business.IBS;
using OKR_Steam.Controllers.IC;
using OKR_Steam.DataAccess.DA;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Controllers.C
{
    [ApiController]
    [Route("[controller]")]
    public class SteamController : Controller, ISteamController
    {
        private readonly ISteamBusiness _steamBusiness;
        private readonly AppDbContext _appDbContext;
        public SteamController(ISteamBusiness steamBusiness, AppDbContext appDbContext)
        {
            _steamBusiness = steamBusiness;
            _appDbContext = appDbContext;
        }


        #region GET METHODS

        [HttpGet("GetSteamProfileDataByName/{username}")]
        public IActionResult GetSteamProfileDataByName(string username)
        {
            var returnData = _steamBusiness.GetSteamProfileDataByName(username);
            return Ok(returnData);
        }

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
