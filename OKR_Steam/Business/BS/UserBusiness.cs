namespace OKR_Steam.Business.BS
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserDataAccess _steamDataAccess;

        public UserBusiness(IUserDataAccess steamDataAccess)
        {
            _steamDataAccess = steamDataAccess;
        }

        public ProcessResult<SteamProfileModel> GetSteamProfileDataByName(string username)
        {
            var returnData = new ProcessResult<SteamProfileModel>();
            returnData.ReturnData = new SteamProfileModel();
            var dbResponse = new SteamProfileDBResponse();

            dbResponse = _steamDataAccess.GetSteamProfileDataByName(username);

            if (dbResponse != null && dbResponse.Id != null)
                try
                {
                    returnData.ReturnData.response = new Response
                    {
                        players = new List<Player> {
                            new Player()
                            {
                                Id = dbResponse.Id,
                                steamid = dbResponse.SteamId,
                                personaname = dbResponse.Username,
                                profilestate = Enum.IsDefined(typeof(Enums.ProfileStates), dbResponse.ProfileState) == true ?
                                        Enum.GetName(typeof(Enums.ProfileStates), dbResponse.ProfileState) : "Offline",
                                profileurl = dbResponse.ProfileURL,
                                primaryclanid = dbResponse.PrimaryClanId.ToString(),
                                avatarhash = dbResponse.TradeURL,
                                lastlogoff = GetEpochTime(DateTime.Now)
                            }
                        }
                    };
                }
                catch (Exception ex)
                {
                    returnData.HasError = true;
                    returnData.ErrorMessage = ex.Message + " --- " + ex.StackTrace;
                }
            else
            {
                returnData.ErrorMessage = "There is no Profile with that Username";
                returnData.HasError = false;
            }
            return returnData;
        }

        private int GetEpochTime(DateTime now)
        {
            TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }

        public ProcessResult<SteamProfileModel> GetSteamProfileDataFromURL(string profileURL)
        {
            var returnData = new ProcessResult<SteamProfileModel>();
            var dbResponse = new SteamProfileDBResponse();

            dbResponse = _steamDataAccess.GetSteamProfileDataFromURL(profileURL);

            if (dbResponse != null && dbResponse.Id != null)
            {
                try
                {
                    returnData.ReturnData.response.players.Add(new Player()
                    {
                        steamid = dbResponse.SteamId,
                        personaname = dbResponse.Username,
                        profilestate = Enum.IsDefined(typeof(Enums.ProfileStates), dbResponse.ProfileState) == true ?
                                        Enum.GetName(typeof(Enums.ProfileStates), dbResponse.ProfileState) : "Offline",
                        profileurl = dbResponse.ProfileURL,
                        primaryclanid = dbResponse.PrimaryClanId.ToString(),
                        avatarhash = dbResponse.TradeURL,
                        lastlogoff = GetEpochTime(DateTime.Now)
                    });
                }
                catch (Exception ex)
                {
                    returnData.HasError = true;
                    returnData.ErrorMessage = ex.Message + " --- " + ex.StackTrace;
                }
            }
            else
            {
                returnData.ErrorMessage = "There is no Profile with that ProfileURL";
                returnData.HasError = false;
            }
            return returnData;

        }
        public ProcessResult<SteamProfileModel> GetSteamUserStatusByUsername(string username)
        {
            var returnData = new ProcessResult<SteamProfileModel>();
            var dbResponse = new SteamProfileDBResponse();

            dbResponse = _steamDataAccess.GetSteamProfileDataByName(username);
            if (dbResponse != null && dbResponse.Id != null)
            {
                try
                {
                    returnData.ReturnData.response = new Response
                    {
                        players = new List<Player>
                        {
                            new Player()
                            {
                                steamid = dbResponse.SteamId,
                                personaname = dbResponse.Username,
                                profilestate = Enum.IsDefined(typeof(Enums.ProfileStates), dbResponse.ProfileState) == true ?
                                            Enum.GetName(typeof(Enums.ProfileStates), dbResponse.ProfileState) : "Offline",
                            }
                        }
                    };
                }
                catch (Exception ex)
                {
                    returnData.HasError = true;
                    returnData.ErrorMessage = ex.Message + " --- " + ex.StackTrace;
                }
            }
            else
            {
                returnData.ErrorMessage = "There is no Profile with that Username";
                returnData.HasError = false;
            }
            return returnData;
        }

        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SteamProfileRequestModel steamProfileModel)
        {
            var returnData = new ProcessResult<SteamProfileDatabaseModel>();

            var dbModel = new SaveSteamProfileData();

            dbModel.ProfileURL = steamProfileModel.ProfileURL;
            dbModel.ProfileState = (int)Enums.ProfileStates.Online;
            dbModel.PrimaryClanId = Guid.NewGuid().ToString();
            dbModel.UniqueId = Guid.NewGuid().ToString();
            dbModel.Username = steamProfileModel.Username;
            dbModel.SteamId = GetSteamIdFromGuid(Guid.NewGuid());
            dbModel.TradeURL = steamProfileModel.TradeURL;
            dbModel.LastUpdated = GetEpochTime(DateTime.Now);

            try
            {
                returnData.ReturnData = _steamDataAccess.SaveSteamProfileData(dbModel);
            }
            catch (Exception ex)
            {
                returnData.HasError = true;
                returnData.ErrorMessage = ex.Message + " --- " + ex.StackTrace;
            }
            return returnData;
        }

        private string GetSteamIdFromGuid(Guid guid)
        {
            return long.Parse(guid.ToString().Replace("-", "").ToLower().Substring(0, 12).ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
        }


        public ProcessResult<SteamProfileDatabaseModel> UpdateSteamProfileDataByUsername(UpdateSteamProfileData steamProfileModel)
        {
            var returnData = new ProcessResult<SteamProfileDatabaseModel>();
            var dbModel = new UpdateSteamProfileData();

            //Check if User exists
            var dbProfileResponse = GetSteamProfileDataByName(steamProfileModel.Username != null ? steamProfileModel.Username : String.Empty).ReturnData;
            if (dbProfileResponse.response.players.Count > 0)// UserExists
            {
                //Check the updated areas.
                dbModel.SteamId = dbProfileResponse.response.players[0].steamid;
                dbModel.Username = dbProfileResponse.response.players[0].personaname;
                dbModel.ProfileState = String.IsNullOrEmpty(Enum.GetName(typeof(Enums.ProfileStates), steamProfileModel.ProfileState)) == true
                    ? (int)((Enums.ProfileStates)Enum.Parse(typeof(Enums.ProfileStates), dbProfileResponse.response.players[0].profilestate))
                    : steamProfileModel.ProfileState;
                dbModel.ProfileURL = String.IsNullOrEmpty(steamProfileModel.ProfileURL) == true
                    ? dbProfileResponse.response.players[0].profileurl
                    : steamProfileModel.ProfileURL;
                dbModel.PrimaryClanId = String.IsNullOrEmpty(steamProfileModel.PrimaryClanId) == true ? dbProfileResponse.response.players[0].primaryclanid : steamProfileModel.PrimaryClanId;
                dbModel.TradeURL = String.IsNullOrEmpty(steamProfileModel.TradeURL) != true ? steamProfileModel.TradeURL : dbProfileResponse.response.players[0].avatarhash;
                dbModel.LastUpdated = GetEpochTime(DateTime.Now);
            }
            try
            {
                returnData.ReturnData = _steamDataAccess.UpdateSteamProfileDataByUsername(dbModel);
            }
            catch (Exception ex)
            {
                returnData.HasError = true;
                returnData.ErrorMessage = ex.Message + " --- " + ex.StackTrace;
            }
            return returnData;


        }
    }
}
