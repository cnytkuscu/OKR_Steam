namespace OKR_Steam.Models.DBModels.DBResponseModels
{
    public class SteamProfileDBResponse
    {
        public string UniqueId { get; set; }
        public string SteamId { get; set; }
        public string Username { get; set; }
        public int ProfileState { get; set; }
        public string ProfileURL { get; set; }
        public Guid PrimaryClanId  { get; set; }
        public string TradeURL { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
