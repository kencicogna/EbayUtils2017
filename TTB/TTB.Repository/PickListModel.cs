using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTB.Repository
{
    public class PickListModel
    {
        public string SKU { get; set; }          // PK
        public string Location { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string Variation { get; set; }
        public string DIFlag { get; set; }
    }
}
