using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTB.Repository
{
    public class InventoryModel
    {
        public Int32 Id { get; set; }
        public string SKU { get; set; }
        public string Variation { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public Decimal Cost { get; set; }
        public string Supplier { get; set; }
        public string ImageURL { get; set; }
        public string MainImageURL { get; set; }
        public Decimal Weight { get; set; }
        public Decimal PackagedWeight { get; set; }
        public string Packaging { get; set; }
        public string BubbleWrap{ get; set; }
        public string EbayItemID { get; set; }
        public string EbayItemHistoryID { get; set; }
        public string ASIN { get; set; }
        public string UPC { get; set; }
        public string Location { get; set; }
        public int Active { get; set; }
        public DateTime LastModified { get; set; }
    }
}
