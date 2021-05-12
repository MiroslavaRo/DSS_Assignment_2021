using System;
using System.Collections.Generic;

#nullable disable

namespace ProductStoreEditor.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
