namespace Resources.ResponseModels
{
      
    public class SteamProfileModel
    {
        public Response response { get; set; }
    }
    public class Player
    {
        public string Id { get; set; }
        public string steamid { get; set; }
        public int communityvisibilitystate { get; set; }
        public string profilestate { get; set; }
        public string personaname { get; set; }
        public int commentpermission { get; set; }
        public string profileurl { get; set; }
        public string avatar { get; set; }
        public string avatarmedium { get; set; }
        public string avatarfull { get; set; }
        public string avatarhash { get; set; }
        public int lastlogoff { get; set; }
        public int personastate { get; set; }
        public string primaryclanid { get; set; }
        public int timecreated { get; set; }
        public int personastateflags { get; set; }
        public string loccountrycode { get; set; }
    }

    public class Response
    {
        public List<Player> players { get; set; }
    }


}
