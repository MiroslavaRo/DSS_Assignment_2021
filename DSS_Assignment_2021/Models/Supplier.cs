using System;
using System.Collections.Generic;

#nullable disable

namespace DSS_Assignment_2021.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string LogoFileName { get; set; }
        public int? ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public static explicit operator int(Supplier v)
        {
            throw new NotImplementedException();
        }
    }
}
