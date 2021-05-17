using System;
using System.Collections.Generic;

#nullable disable

namespace ProductStoreDatabase.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string Company { get; set; }
        public int? ProductTypeId { get; set; }
        public string LogoFileName { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
