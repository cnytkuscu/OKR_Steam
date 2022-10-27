using OKR_Steam.DataAccess.IDA;
using OKR_Steam.Models.DBModels;
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


        public SteamProfileModel GetSteamProfileDataFromURL(string profileURL)
        {
            var returnData = new SteamProfileModel();


            var dbData = context.SteamProfile.FirstOrDefault(x => x.profileurl == profileURL);
            if (dbData != null)
            {
                returnData.response = new Response()
                {
                    players = new List<Player>()
                    {
                        new Player()
                        {
                            steamid = dbData.steamid,
                            profilestate = dbData.profilestate,
                            profileurl = dbData.profileurl,
                            primaryclanid = dbData.primaryclanid
                        }
                    }
                };
            }


            return returnData;
        }

        public ProcessResult<SteamProfileDatabaseModel> SaveSteamProfileData(SteamProfileRequestModel steamProfileModel)
        {
            var data = new SteamProfileDatabaseModel();
            data.Id = steamProfileModel.Id;
            data.profilestate = steamProfileModel.profilestate;
            data.profileurl = steamProfileModel.profileurl;
            data.steamid = steamProfileModel.steamid;
            data.primaryclanid = steamProfileModel.primaryclanid;
            data.uniqueId = Guid.NewGuid().ToString();

            try
            {
                // Database'e ekletiyoruz burada.
                // Database.Add(data);
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
