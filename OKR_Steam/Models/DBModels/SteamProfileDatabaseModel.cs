namespace OKR_Steam.Models.DBModels
{
    public class SteamProfileDatabaseModel
    {
        public string Id { get; set; }
        public Guid uniqueId{ get; set; }
        public string steamid { get; set; }
        public int profilestate { get; set; }
        public string profileurl { get; set; }
        public string primaryclanid { get; set; }
    }
}
