using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.DBModels.Tables
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
