

namespace Resources.ResponseModels
{
    public class SteamItemModel
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCondition { get; set; }
        public decimal ItemFloat { get; set; }
        public bool HasSticker { get; set; }
        public Guid? StickerId { get; set; }
    }
}
