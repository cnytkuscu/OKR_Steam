﻿namespace OKR_Steam.Models.DBModels.DBResponseModels
{
    public class SteamInventoryDBResponseModel
    {
        public Guid Id { get; set; }
        public Guid SteamId { get; set; }
        public Guid ItemId { get; set; }
        public int Status { get; set; }

    }
}