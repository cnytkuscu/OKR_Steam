namespace OKR_Steam.Models.ResponseModels
{
    public class SteamInventoryModel
    {
        public string Username { get; set; }
        public string SteamId { get; set; }
        public List<ItemDetail> ItemDetail { get; set; }
          
    }

    public class ItemDetail
    {
        public string ItemName { get; set; }
        public string ItemCondition { get; set; }
        public decimal ItemFloat { get; set; }
        public bool HasSticker { get; set; }
    }
}
