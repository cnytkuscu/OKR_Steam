namespace OKR_Steam.Models.RequestModels
{
    public class SteamProfileRequestModel
    {
        public string Id { get; set; }
        public string steamid { get; set; }
        public int profilestate { get; set; }
        public string profileurl { get; set; }
        public string primaryclanid { get; set; }

    }
}
