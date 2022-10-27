using OKR_Steam.Business.IBS;
using OKR_Steam.DataAccess.DA;
using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.DBModels;
using OKR_Steam.Models.DBModels.DBRequestModels;
using OKR_Steam.Models.DBModels.DBResponseModels;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;
using System;

namespace OKR_Steam.Business.BS
{
    public class SteamBusiness : ISteamBusiness
    {
        private readonly ISteamDataAccess _steamDataAccess;
        private readonly AppDbContext _context;
        public SteamBusiness(ISteamDataAccess steamDataAccess, AppDbContext context)
        {
            _steamDataAccess = steamDataAccess;
            _context = context;

        }

        public SteamProfileModel GetSteamProfileDataByName(string username)
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
                profilestate = dbResponse.ProfileState,
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
                    profilestate = dbResponse.ProfileState,
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
           return long.Parse(guid.ToString().Replace("-", "").ToLower().Substring(0,12).ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
        }
    }
}
