using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.DBModels;
using OKR_Steam.Models.DBModels.DBRequestModels;
using OKR_Steam.Models.DBModels.DBResponseModels;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.DataAccess.DA
{
    public class SteamDataAccess : ISteamDataAccess
    {
        private readonly AppDbContext context;
        public SteamDataAccess(AppDbContext _context)
        {
            context = _context;
        }

        public SteamProfileDBResponse GetSteamProfileDataByName(string username)
        {
            var returnData = new SteamProfileDBResponse();

            var dbData = context.SteamProfile.FirstOrDefault(x => x.Username == username);

            returnData.SteamId = dbData.SteamId;
            returnData.Username = username;
            returnData.ProfileState = dbData.ProfileState;
            returnData.ProfileURL = dbData.ProfileURL;
            returnData.PrimaryClanId = dbData.PrimaryClanId;
            returnData.TradeURL = dbData.TradeURL;

            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            start = start.AddSeconds(dbData.LastUpdated);
            returnData.LastUpdated = start;


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

        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SaveSteamProfileData steamProfileModel)
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

            try
            {
                context.SteamProfile.Add(data);
                context.SaveChanges();
                return new ProcessResult<SteamProfileDatabaseModel> { HasError = false, ReturnData = data, ErrorMessage = "" };
            }
            catch (Exception)
            {
                // Hata Alındığını varsayıyoruz.
                return new ProcessResult<SteamProfileDatabaseModel> { HasError = true, ReturnData = data, ErrorMessage = "Error happened while adding new record to database." };
            }
        }
    }
}
