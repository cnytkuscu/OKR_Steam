using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.DBModels;
using OKR_Steam.Models.RequestModels;
using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.DataAccess.DA
{
    public class SteamDataAccess : ISteamDataAccess
    {
        public SteamDataAccess()
        {
        }

        public SteamProfileModel GetSteamProfileDataFromURL(string profileURL)
        {
            var returnData = new SteamProfileModel();

            returnData.response = new Response
            {
                players = new List<Player>() { new Player
                {
                    steamid = "76561198137937316",
                    personaname = "Tyenuc",
                    lastlogoff = 1665696761,
                    primaryclanid = "103582791470454970",
                    timecreated = 1401007545,
                    personastate = 0,
                    loccountrycode = "IE"
                }}
            };

            return returnData;
        }

        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SteamProfileRequestModel steamProfileModel)
        {
            var data = new SteamProfileDatabaseModel();

            data.profilestate = steamProfileModel.profilestate;
            data.profileurl = steamProfileModel.profileurl;
            data.steamid = steamProfileModel.steamid;
            data.primaryclanid = steamProfileModel.primaryclanid;
            data.uniqueId = Guid.NewGuid();

            try
            {
                // Database'e ekletiyoruz burada.
                // Database.Add(data);
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
