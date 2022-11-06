namespace OKR_Steam.Models.DBModels.Tables
{
    public class ItemDatabaseModel
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemCondition { get; set; }
        public decimal ItemFloat { get; set; }
        public bool HasSticker { get; set; }
        public Guid? StickerId { get; set; }
    }
}
