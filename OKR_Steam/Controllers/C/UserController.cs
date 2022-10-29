using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Business.BS;
using OKR_Steam.Business.IBS;
using OKR_Steam.Controllers.IC;
using OKR_Steam.DataAccess.DA;
using OKR_Steam.Models.DBModels.DBRequestModels;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Controllers.C
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller, IUserController
    {
        private readonly IUserBusiness _userBusiness;
        
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;           
        }


        #region GET METHODS

        [HttpGet("GetSteamProfileDataByName/{username}")]
        public IActionResult GetSteamProfileDataByName(string username)
        {
            var returnData = _userBusiness.GetSteamProfileDataByName(username);
            return Ok(returnData);
        }

        [HttpGet("GetSteamProfileDataFromURL/{profileURL}")]
        public IActionResult GetSteamProfileDataFromURL(string profileURL)
        {
            var returnData = _userBusiness.GetSteamProfileDataFromURL(profileURL);

            return Ok(returnData);
        }

        [HttpGet("SteamUserStatusByUsername/{username}")]
        public IActionResult GetSteamUserStatusByUsername(string username)
        {
            return Ok();
        }


        #endregion


        #region POST METHODS
        [HttpPost("SaveSteamProfileData")]
        public IActionResult SaveSteamProfileData(SteamProfileRequestModel steamProfileModel)
        {
            var returnData = _userBusiness.SaveSteamProfileData(steamProfileModel);
            return Ok(returnData);
        }



        #endregion


        #region PUT METHODS

        [HttpPut("UpdateSteamProfileDataByUsername")]
        public IActionResult UpdateSteamProfileDataByUsername(UpdateSteamProfileData steamProfileModel)
        {
            var returnData = _userBusiness.UpdateSteamProfileDataByUsername(steamProfileModel);
            return Ok();
        }
        #endregion



        #region DELETE METHODS
        #endregion


    }
}
