using System;
using System.Collections.Generic;

#nullable disable

namespace DSS_Assignment_2021.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
            Suppliers = new HashSet<Supplier>();
        }

        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
