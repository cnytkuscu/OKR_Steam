using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.DBModels.Tables
{
    public class SteamProfileDatabaseModel
    {
        public Guid Id { get; set; }
        public string SteamId { get; set; }
        public string Username { get; set; }
        public int ProfileState { get; set; }
        public string ProfileURL { get; set; }
        public Guid PrimaryClanId { get; set; }
        public string TradeURL { get; set; }
        public int LastUpdated { get; set; }
    }
}
