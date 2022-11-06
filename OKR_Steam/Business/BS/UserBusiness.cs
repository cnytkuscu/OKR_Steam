using OKR_Steam.Business.IBS;
using OKR_Steam.DataAccess.DA;
using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.DBModels;
using OKR_Steam.Models.DBModels.DBRequestModels;
using OKR_Steam.Models.DBModels.DBResponseModels;
using OKR_Steam.Models.DBModels.Tables;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;
using System;
using System.Reflection.Metadata.Ecma335;

namespace OKR_Steam.Business.BS
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserDataAccess _steamDataAccess;
        private readonly AppDbContext _context;
        public UserBusiness(IUserDataAccess steamDataAccess, AppDbContext context)
        {
            _steamDataAccess = steamDataAccess;
            _context = context;
        }

        public SteamProfileModel GetSteamProfileDataByName(string username)
        {
            var returnData = new SteamProfileModel();
            var dbResponse = new SteamProfileDBResponse();

            if (String.IsNullOrEmpty(username)) return returnData;

            dbResponse = _steamDataAccess.GetSteamProfileDataByName(username);

            returnData.response = new Response
            {
                players = new List<Player>{
                    new Player()
                    {
                        Id = dbResponse.Id,
                        steamid = dbResponse.SteamId,
                        personaname = dbResponse.Username,
                        profilestate = Enum.IsDefined(typeof(Enums.Enums.ProfileStates),dbResponse.ProfileState) == true ?
                                        Enum.GetName(typeof(Enums.Enums.ProfileStates),dbResponse.ProfileState) : "Offline",
                        profileurl = dbResponse.ProfileURL,
                        primaryclanid = dbResponse.PrimaryClanId.ToString(),
                        avatarhash = dbResponse.TradeURL,
                        lastlogoff = GetEpochTime(DateTime.Now)
                    }
                }
            };

            return returnData;
        }

        private int GetEpochTime(DateTime now)
        {
            TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }

        public SteamProfileModel GetSteamProfileDataFromURL(string profileURL)
        {
            var returnData = new SteamProfileModel();
            var dbResponse = new SteamProfileDBResponse();

            dbResponse = _steamDataAccess.GetSteamProfileDataFromURL(profileURL);

            if (dbResponse.SteamId != null)
            {
                returnData.response.players.Add(new Player()
                {
                    steamid = dbResponse.SteamId,
                    personaname = dbResponse.Username,
                    profilestate = Enum.IsDefined(typeof(Enums.Enums.ProfileStates), dbResponse.ProfileState) == true ?
                                        Enum.GetName(typeof(Enums.Enums.ProfileStates), dbResponse.ProfileState) : "Offline",
                    profileurl = dbResponse.ProfileURL,
                    primaryclanid = dbResponse.PrimaryClanId.ToString(),
                    avatarhash = dbResponse.TradeURL,
                    lastlogoff = GetEpochTime(DateTime.Now)
                });
            }



            return returnData;

        }

        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SteamProfileRequestModel steamProfileModel)
        {
            var returnData = new ProcessResult<SteamProfileDatabaseModel>();

            var dbModel = new SaveSteamProfileData();

            dbModel.ProfileURL = steamProfileModel.ProfileURL;
            dbModel.ProfileState = (int)Enums.Enums.ProfileStates.Online;
            dbModel.PrimaryClanId = Guid.NewGuid().ToString();
            dbModel.UniqueId = Guid.NewGuid().ToString();
            dbModel.Username = steamProfileModel.Username;
            dbModel.SteamId = GetSteamIdFromGuid(Guid.NewGuid());
            dbModel.TradeURL = steamProfileModel.TradeURL;
            dbModel.LastUpdated = GetEpochTime(DateTime.Now);



            returnData = _steamDataAccess.SaveSteamProfileData(dbModel);
            return returnData;
        }

        private string GetSteamIdFromGuid(Guid guid)
        {
            return long.Parse(guid.ToString().Replace("-", "").ToLower().Substring(0, 12).ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
        }

        public SteamProfileModel GetSteamUserStatusByUsername(string username)
        {
            var returnData = new SteamProfileModel();
            var dbResponse = new SteamProfileDBResponse();

            dbResponse = _steamDataAccess.GetSteamProfileDataByName(username);

            returnData.response = new Response
            {
                players = new List<Player>{
                    new Player()
                    {
                        steamid = dbResponse.SteamId,
                        personaname = dbResponse.Username,
                        profilestate = Enum.IsDefined(typeof(Enums.Enums.ProfileStates),dbResponse.ProfileState) == true ?
                                        Enum.GetName(typeof(Enums.Enums.ProfileStates),dbResponse.ProfileState) : "Offline",
                    }
                }
            };

            return returnData;
        }

        public ProcessResult<SteamProfileDatabaseModel> UpdateSteamProfileDataByUsername(UpdateSteamProfileData steamProfileModel)
        {
            var returnData = new ProcessResult<SteamProfileDatabaseModel>();
            var dbModel = new UpdateSteamProfileData();

            //Check if User exists
            var dbProfileResponse = GetSteamProfileDataByName(steamProfileModel.Username != null ? steamProfileModel.Username : String.Empty);
            if (dbProfileResponse.response.players.Count > 0)// UserExists
            {
                //Check the updated areas.
                dbModel.SteamId = dbProfileResponse.response.players[0].steamid;
                dbModel.Username = dbProfileResponse.response.players[0].personaname;
                dbModel.ProfileState = String.IsNullOrEmpty(Enum.GetName(typeof(Enums.Enums.ProfileStates), steamProfileModel.ProfileState)) == true 
                    ? (int)((Enums.Enums.ProfileStates)Enum.Parse(typeof(Enums.Enums.ProfileStates), dbProfileResponse.response.players[0].profilestate)) 
                    : steamProfileModel.ProfileState;
                dbModel.ProfileURL = String.IsNullOrEmpty(steamProfileModel.ProfileURL) == true
                    ? dbProfileResponse.response.players[0].profileurl
                    : steamProfileModel.ProfileURL;
                dbModel.PrimaryClanId = String.IsNullOrEmpty(steamProfileModel.PrimaryClanId) == true ? dbProfileResponse.response.players[0].primaryclanid : steamProfileModel.PrimaryClanId;
                dbModel.TradeURL = String.IsNullOrEmpty(steamProfileModel.TradeURL) != true ? steamProfileModel.TradeURL : dbProfileResponse.response.players[0].avatarhash;
                dbModel.LastUpdated = GetEpochTime(DateTime.Now);
            }
            returnData = _steamDataAccess.UpdateSteamProfileDataByUsername(dbModel);
            return returnData;


        }
    }
}
