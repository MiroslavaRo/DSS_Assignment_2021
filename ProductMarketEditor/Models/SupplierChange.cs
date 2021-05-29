using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMarketEditor.Models
{
    public class SupplierChange
    {
        public SupplierChange()
        {
            Suppliers = new HashSet<Supplier>();
        }
        public int SupplierChangeId { get; set; }
        public string EditedBy { get; set; }
        public string CreatedBy { get; set; }
        public string EditedOn { get; set; }
        public string CreatedOn { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
