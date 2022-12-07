using Microsoft.AspNetCore.Mvc;
using OKR_Steam.Business.IBS;
using OKR_Steam.Validators.UserValidators;

namespace OKR_Steam.Controllers.C
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }


        #region GET METHODS

        [HttpGet("GetSteamProfileDataByName/{username}")]
        public ProcessResult<SteamProfileModel> GetSteamProfileDataByName(string username)
        {
            var returnData = new ProcessResult<SteamProfileModel>();

            var requestData = new SteamProfileRequestModel()
            {
                Username = username
            };
            var validation = new SteamProfileRequestModelValidator().Validate(requestData);

            if (validation.IsValid) returnData = _userBusiness.GetSteamProfileDataByName(username);
            else { returnData.HasError = true; returnData.ErrorMessage = String.Join(" --- ", validation.Errors); }
            return returnData;
        }

        [HttpGet("GetSteamProfileDataFromURL/{profileURL}")]
        public ProcessResult<SteamProfileModel> GetSteamProfileDataFromURL(string profileURL)
        {
            var returnData = new ProcessResult<SteamProfileModel>();

            var requestData = new SteamProfileRequestModel()
            {
                ProfileURL = profileURL
            };

            var validation = new SteamProfileRequestModelValidator().Validate(requestData);
            if (validation.IsValid) returnData = _userBusiness.GetSteamProfileDataFromURL(profileURL);
            else { returnData.HasError = true; returnData.ErrorMessage = String.Join(" --- ", validation.Errors); }

            return returnData;
        }

        [HttpGet("SteamUserStatusByUsername/{username}")]
        public ProcessResult<SteamProfileModel> GetSteamUserStatusByUsername(string username)
        {
            var returnData = new ProcessResult<SteamProfileModel>();
            var requestData = new SteamProfileRequestModel()
            {
                Username= username
            };

            var validation = new SteamProfileRequestModelValidator().Validate(requestData);
            if (validation.IsValid) returnData = _userBusiness.GetSteamUserStatusByUsername(username);
            else { returnData.HasError = true; returnData.ErrorMessage = String.Join(" --- ", validation.Errors); }

            return returnData;
        }


        #endregion


        #region POST METHODS
        [HttpPost("SaveSteamProfileData")]
        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SteamProfileRequestModel steamProfileModel)
        {
            var returnData = new ProcessResult<SteamProfileDatabaseModel>();
            returnData = _userBusiness.SaveSteamProfileData(steamProfileModel);
            return returnData;
        }



        #endregion


        #region PUT METHODS

        [HttpPut("UpdateSteamProfileDataByUsername")]
        public ProcessResult<SteamProfileDatabaseModel> UpdateSteamProfileDataByUsername(UpdateSteamProfileData steamProfileModel)
        {
            var returnData = new ProcessResult<SteamProfileDatabaseModel>();
            returnData = _userBusiness.UpdateSteamProfileDataByUsername(steamProfileModel);
            return returnData;
        }
        #endregion



        #region DELETE METHODS
        #endregion


    }
}
