using OKR_Steam.DataAccess.IDA;
using Resources.AppDbContex;
using Resources.DBModels.RequestModels;
using Resources.DBModels.ResponseModels;
using Resources.DBModels.Tables;

namespace OKR_Steam.DataAccess.DA
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly AppDbContext context;
        public UserDataAccess(AppDbContext _context)
        {
            context = _context;
        }

        public SteamProfileDBResponse GetSteamProfileDataByName(string username)
        {
            var returnData = new SteamProfileDBResponse();

            var dbData = context.SteamProfile.FirstOrDefault(x => x.Username == username);

            if (dbData != null)
            {
                returnData.Id = dbData.Id.ToString();
                returnData.SteamId = dbData.SteamId;
                returnData.Username = username;
                returnData.ProfileState = dbData.ProfileState;
                returnData.ProfileURL = dbData.ProfileURL;
                returnData.PrimaryClanId = dbData.PrimaryClanId;
                returnData.TradeURL = dbData.TradeURL;

                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                start = start.AddSeconds(dbData.LastUpdated);
                returnData.LastUpdated = start;
            }

            return returnData;
        }

        public SteamProfileDBResponse GetSteamProfileDataFromURL(string profileURL)
        {
            var returnData = new SteamProfileDBResponse();

            var dbData = context.SteamProfile.FirstOrDefault(x => x.ProfileURL == profileURL);
            if (dbData != null)
            {
                returnData.SteamId = dbData.SteamId;
                returnData.Username = dbData.Username;
                returnData.ProfileState = dbData.ProfileState;
                returnData.ProfileURL = profileURL;
                returnData.PrimaryClanId = dbData.PrimaryClanId;
                returnData.TradeURL = dbData.TradeURL;

                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                start = start.AddSeconds(dbData.LastUpdated);
                returnData.LastUpdated = start;
            }
            return returnData;
        }

        public SteamProfileDBResponse GetSteamUserStatusByUsername(string username)
        {
            var returnData = new SteamProfileDBResponse();

            var dbData = context.SteamProfile.FirstOrDefault(x => x.Username == username);
            if (dbData != null)
            {
                returnData.SteamId = dbData.SteamId;
                returnData.Username = dbData.Username;
                returnData.ProfileState = dbData.ProfileState;
            }
            return returnData;
        }

        public SteamProfileDatabaseModel SaveSteamProfileData(SaveSteamProfileData steamProfileModel)
        {
            var data = new SteamProfileDatabaseModel();
            data.SteamId = steamProfileModel.SteamId;
            data.Username = steamProfileModel.Username;
            data.ProfileState = steamProfileModel.ProfileState;
            data.ProfileURL = steamProfileModel.ProfileURL;
            data.PrimaryClanId = Guid.Parse(steamProfileModel.PrimaryClanId);
            data.Id = Guid.Parse(steamProfileModel.UniqueId);
            data.LastUpdated = steamProfileModel.LastUpdated;
            data.TradeURL = steamProfileModel.TradeURL;

            context.SteamProfile.Add(data);
            context.SaveChanges();
            return data;
        }

        public SteamProfileDatabaseModel UpdateSteamProfileDataByUsername(UpdateSteamProfileData steamProfileData)
        {
            var dbData = context.SteamProfile.FirstOrDefault(x => x.Username == steamProfileData.Username);
            if (dbData != null)
            {
                dbData.ProfileState = steamProfileData.ProfileState;
                dbData.ProfileURL = steamProfileData.ProfileURL;
                dbData.PrimaryClanId = Guid.Parse(steamProfileData.PrimaryClanId);
                dbData.TradeURL = steamProfileData.TradeURL;
                dbData.LastUpdated = steamProfileData.LastUpdated;

                context.SteamProfile.Update(dbData);
                context.SaveChanges();
            }
            return dbData;


        }
    }
}
