using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDB.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}