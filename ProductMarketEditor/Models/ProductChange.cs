using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMarketEditor.Models
{
    public class ProductChange
    {
        public int ProductChangeId { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public string EditedBy { get; set; }
        public string CreatedBy { get; set; }
        public string EditedOn { get; set; }
        public string CreatedOn { get; set; }
       // public virtual Product Product { get; set; }

    }
}
